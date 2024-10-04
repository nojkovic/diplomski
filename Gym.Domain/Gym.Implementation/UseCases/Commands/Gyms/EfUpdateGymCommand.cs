using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Gym;
using Gym.Application.UseCases.Commands.Gyms;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Gym;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Gyms
{
    public class EfUpdateGymCommand : EfUseCase, IUpdateGymCommand
    {
        private UpdateGymDTOValidator validator;
        public EfUpdateGymCommand(GymContext context, UpdateGymDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 58;

        public string Name => "Gym Update";

        public void Execute(UpdateGymDTO data)
        {
            validator.ValidateAndThrow(data);

            var g = Context.Gyms
                .Include(g => g.Photos)
                .Include(g => g.CoachTraining)
                .ThenInclude(ct => ct.Coach)
                .FirstOrDefault(x => x.Id == data.Id);

            if (g == null)
            {
                throw new Exception("Gym not found.");
            }

            g.Contact = data.Contact ?? g.Contact;
            g.Name = data.Name ?? g.Name;
            g.WorkingTime = data.WorkingTime ?? g.WorkingTime;
            g.WorkingTimeOnWeekend = data.WorkingTimeOnWeekend ?? g.WorkingTimeOnWeekend;
            g.Description = data.Description ?? g.Description;
            g.Location = new Location
            {
                Address = data.Location?.Address ?? g.Location.Address,
                City = data.Location?.City ?? g.Location.City
            };


            if (data.PhotosString != null && data.PhotosString.Any())
            {
                using (var transaction = Context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var photo in g.Photos.ToList())
                        {
                            photo.IsActive = false;
                        }

                        var newPhotos = data.PhotosString.Select(ph =>
                        {
                            var tempFile = Path.Combine("wwwroot", "temp", ph);
                            var destinationFile = Path.Combine("wwwroot", "gym", ph);

                            if (System.IO.File.Exists(tempFile))
                            {
                                System.IO.File.Move(tempFile, destinationFile);
                            }

                            return new Domain.Photo
                            {
                                Path = ph,
                                IsActive = true
                            };
                        }).ToList();

                        g.Photos = newPhotos;
                        Context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("An error occurred while updating photos: " + ex.Message);
                    }
                }
            }
            if (data.Coaches != null && data.Coaches.Any())
                { 
                    using (var transaction = Context.Database.BeginTransaction())
                    {
                        try
                        {
                            var existingCoaches = g.CoachTraining.Select(ct => ct.Coach).ToList();

                            foreach (var coach in existingCoaches)
                            {
                                if (!data.Coaches.Any(c => c.Id == coach.Id))
                                {
                                    coach.IsActive = false;
                                }
                            }

                            foreach (var coachDto in data.Coaches)
                            {
                                var coach = new Domain.Coach
                                {
                                    Name = coachDto.Name,
                                    LastName = coachDto.LastName,
                                    Photo = !string.IsNullOrEmpty(coachDto.Photo) ? MoveCoachPhotoFromTempToCoachFolder(coachDto.Photo) : null,
                                    Description = coachDto.Description,
                                    Gym = g
                                };

                                Context.Coachs.Add(coach);
                                Context.SaveChanges(); 

                                var existingCoachTrainingIds = Context.CoachTrainings
                                    .Where(ct => ct.CoachId == coach.Id)
                                    .Select(ct => ct.TrainingId)
                                    .ToList();

                                var coachTrainingsToRemove = Context.CoachTrainings
                                    .Where(ct => ct.CoachId == coach.Id && !coachDto.TrainingIds.Contains(ct.TrainingId))
                                    .ToList();

                                coachTrainingsToRemove.ForEach(ct => ct.IsActive = false);

                                foreach (var trainingId in coachDto.TrainingIds)
                                {
                                    if (!existingCoachTrainingIds.Contains(trainingId))
                                    {
                                        var coachTraining = new CoachTraining
                                        {
                                            CoachId = coach.Id,
                                            TrainingId = trainingId,
                                            Gym = g
                                        };
                                        Context.CoachTrainings.Add(coachTraining);
                                    }
                                }
                            }

                            Context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("An error occurred while updating coaches or coach trainings: " + ex.Message);
                        }
                    }
        }

            Context.SaveChanges();
    }

            private string MoveCoachPhotoFromTempToCoachFolder(string photoPath)
        {
            if (string.IsNullOrEmpty(photoPath))
                return null;

            var tempFile = Path.Combine("wwwroot", "temp", photoPath);
            var destinationFile = Path.Combine("wwwroot", "coach", photoPath);

            if (System.IO.File.Exists(tempFile))
            {
                System.IO.File.Move(tempFile, destinationFile);
            }

            return photoPath;
        }
    }
}
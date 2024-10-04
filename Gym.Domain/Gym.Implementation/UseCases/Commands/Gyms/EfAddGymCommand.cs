using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.Gym;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.Photo;
using Gym.Application.UseCases.Commands.Gyms;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Gym;

namespace Gym.Implementation.UseCases.Commands.Gyms
{
    public class EfAddGymCommand : EfUseCase, IAddGymCommand
    {
        private AddGymDTOValidator validator;
        public EfAddGymCommand(GymContext context, AddGymDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 57;

        public string Name => "Gym Add";

        public void Execute(GymDTO data)
        {
            validator.ValidateAndThrow(data);

            Domain.Gym g = new Domain.Gym
            {
                Contact = data.Contact,
                Name = data.Name,
                WorkingTime = data.WorkingTime,
                WorkingTimeOnWeekend = data.WorkingTimeOnWeekend,
                Description = data.Description,


                Photos = (data.Photos?.Select(ph =>
                {
                    var tempFile = Path.Combine("wwwroot", "temp", ph.Path);
                    var destinationFile = Path.Combine("wwwroot", "gym", ph.Path);

                    if (System.IO.File.Exists(tempFile))
                    {
                        System.IO.File.Move(tempFile, destinationFile);
                    }

                    return new Domain.Photo
                    {
                        Path = Path.Combine( ph.Path),
                        
                    };
                })
                .Union(data.PhotosString?.Select(ps => new Domain.Photo
                {
                    Path = Path.Combine( ps), 
                 
                }) ?? Enumerable.Empty<Domain.Photo>())) 
                .ToList(),

                Location = new Location
                {
                    Address = data.Location.Address,
                    City = data.Location.City,
                }
            };


            var c = data.Coaches?.Select(x => new Domain.Coach
            {
                Name = x.Name,
                LastName = x.LastName,
                Photo = !string.IsNullOrEmpty(x.Photo) ? MoveCoachPhotoFromTempToCoachFolder(x.Photo) : null,
                Description = x.Description,
                Gym = g,
                CoachTrainings = (x.TrainingIds?.Any() == true) ? x.TrainingIds.Select(id => new CoachTraining
                {
                    TrainingId = id,
                    Gym = g
                }).ToList() : new List<CoachTraining>()
            }).ToList();

            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Gyms.Add(g);
                    Context.SaveChanges();

                    Context.Coachs.AddRange(c);
                    Context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                   
                    throw;
                }
            }
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

   
            return Path.Combine( photoPath);
        }

    }
}


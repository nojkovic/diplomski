using Gym.Application;
using Gym.Implementation.Logging.UseCases;
using Gym.Implementation;
using System.IdentityModel.Tokens.Jwt;
using Gym.Application.UseCases.Commands.Users;
using Gym.Implementation.UseCases.Commands.Users;
using Gym.Application.UseCases.Queries;
using Gym.Implementation.Validators.Users;
using Gym.Application.UseCases.Commands.Contact;
using Gym.Implementation.UseCases.Commands.Contact;
using Gym.Implementation.Validators.Contact;
using Gym.Application.UseCases.Commands.MembershipFees;
using Gym.Implementation.UseCases.Commands.MembershipFees;
using Gym.Implementation.Validators.MembershipFee;
using Gym.Implementation.Validators.GroupTraining;
using Gym.Application.UseCases.Commands.GroupTrainings;
using Gym.Implementation.UseCases.Commands.GroupTrainings;
using Gym.Application.UseCases.Commands.PersonalTrainings;
using Gym.Implementation.UseCases.Commands.PersonalTrainings;
using Gym.Implementation.Validators.PersonalTraining;
using Gym.Application.UseCases.Commands.Locations;
using Gym.Implementation.UseCases.Commands.Locations;
using Gym.Implementation.Validators.Location;
using Gym.Implementation.UseCases.Queries.Contact;
using Gym.Implementation.UseCases.Queries.GroupTraining;
using Gym.Implementation.UseCases.Queries.MembershipFee;
using Gym.Implementation.UseCases.Queries.PersonalTraining;
using Gym.Implementation.UseCases.Queries.User;
using Gym.Implementation.UseCases.Queries.Location;
using Gym.Application.UseCases.Commands.Status;
using Gym.Implementation.UseCases.Commands.Status;
using Gym.Implementation.Validators.Status;
using Gym.Implementation.UseCases.Queries.Status;
using Gym.Application.UseCases.Commands.Photos;
using Gym.Implementation.UseCases.Commands.Photo;
using Gym.Implementation.Validators.Photo;
using Gym.Implementation.UseCases.Queries.Photo;
using Gym.Application.UseCases.Commands.Coach;
using Gym.Implementation.UseCases.Commands.Coachs;
using Gym.Implementation.Validators.Coach;
using Gym.Implementation.UseCases.Queries.Coach;
using Gym.Application.UseCases.Commands.Trainings;
using Gym.Implementation.UseCases.Commands.Trainings;
using Gym.Implementation.Validators.Training;
using Gym.Implementation.UseCases.Queries.Training;
using Gym.Application.UseCases.Commands.CoachTrainings;
using Gym.Implementation.UseCases.Commands.CoachTrainings;
using Gym.Implementation.Validators.CoachTraining;
using Gym.Implementation.UseCases.Queries.CoachTraining;
using Gym.Application.UseCases.Commands.Appointments;
using Gym.Implementation.UseCases.Commands.Appointments;
using Gym.Implementation.Validators.Appointment;
using Gym.Implementation.UseCases.Queries.Appointment;
using Gym.Application.UseCases.Commands.Gyms;
using Gym.Implementation.UseCases.Commands.Gyms;
using Gym.Implementation.Validators.Gym;
using Gym.Implementation.UseCases.Queries.Gym;
using Gym.Application.UseCases.Commands.Reservations;
using Gym.Implementation.UseCases.Commands.Reservations;
using Gym.Implementation.Validators.Reservation;
using Gym.Implementation.UseCases.Queries.Reservation;
using Gym.Application.UseCases.Commands.Contacts;
using Gym.Application.Email;
using Gym.Implementation.Email;
using Gym.Application.UseCases.Commands.Ratings;
using Gym.Implementation.UseCases.Commands.Ratings;
using Gym.Implementation.Validators.Rating;
using Gym.Implementation.UseCases.Queries.Rating;
using Gym.Implementation.UseCases.Queries.Auth;
using Gym.Application.UseCases.Commands.GymTraining;
using Gym.Implementation.UseCases.Commands.GymTrainings;
using Gym.Implementation.Validators.GymTraining;
using Gym.Implementation.UseCases.Queries.GymTraining;

namespace Gym.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<UseCaseHandler>();
            
            services.AddTransient<IUseCaseLogger, SPUseCaseLogger>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<RegisterUserDtoValidator>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<UpdateUserDTOValidator>();
            services.AddTransient<IModifyAccessCommand, EfModifyAccessCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<DeleteUserDTOValidator>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<IDeleteContactCommand, EfDeleteContactCommand>();
            services.AddTransient<DeleteContactDTOValidator>();
            services.AddTransient<IAddContactCommand, EfAddContactCommand>();
            services.AddTransient<ContactValidator>();
            services.AddTransient<IGetContactsQuery, EfGetContactsQuery>();
            services.AddTransient<IAddMembershipFeeCommand, EfAddMembershipFeeCommand>();
            services.AddTransient<AddMembershipFeeDTOValidator>();
            services.AddTransient<IUpdateMembershipFeeCommand, EfUpdateMembershipFeeCommand>();
            services.AddTransient<UpdateMembershipFeeDTOValidator>();
            services.AddTransient<IDeleteMembershipFeeCommand, EfDeleteMembershipFeeCommand>();
            services.AddTransient<DeleteMembershipFeeDTOValidator>();
            services.AddTransient<IGetMembershipFeeQuery,EfGetMembershipFeeQuery>();
            services.AddTransient<IGetMembershipFeesQuery, EfGetMembershipFeesQuery>();
            services.AddTransient<IAddGroupTrainingCommand, EfAddGroupTrainingCommand>();
            services.AddTransient<AddGroupTrainingDTOValidator>();
            services.AddTransient<IUpdateGroupTrainingCommand, EfUpdateGroupTrainingCommand>();
            services.AddTransient<UpdateGroupTrainingDTOValidator>();
            services.AddTransient<IDeleteGroupTrainingCommand, EfDeleteGroupTrainingCommand>();
            services.AddTransient<DeleteGroupTrainingDTOValidator>();
            services.AddTransient<IGetGroupTrainingQuery, EfGetGroupTrainingQuery>();
            services.AddTransient<IGetGroupTrainingsQuery, EfGetGroupTrainingsQuery>();
            services.AddTransient<IAddPersonalTrainingCommand, EffAddPersonalTrainingCommand>();
            services.AddTransient<AddPersonalTrainingDTOValidator>();
            services.AddTransient<IUpdatePersonalTraining, EfUpdatePersonalTrainingCommand>();
            services.AddTransient<UpdatePersonalTrainingDTOValidator>();
            services.AddTransient<IDeletePersonalTrainingCommand, EfDeletePersonalTrainingCommand>();
            services.AddTransient<DeletePersonalTrainingDTOValidator>();
            services.AddTransient<IGetPersonalTrainingQuery, EfGetPersonalTrainingQuery>();
            services.AddTransient<IGetPersonalTrainingsQuery, EfGetPersonalTrainingsQuery>();
            services.AddTransient<IAddLocationCommand, EfAddLocationCommand>();
            services.AddTransient<AddLocationDTOValidator>();
            services.AddTransient<IUpdateLocationCommand, EfUpdateLocationCommand>();
            services.AddTransient<UpdateLocationDTOValidator>();
            services.AddTransient<IDeleteLocationCommand, EfDeleteLocationCommand>();
            services.AddTransient<DeleteLocationDTOValidator>();
            services.AddTransient<IGetLocationQuery, EfGetLocationQuery>();
            services.AddTransient<IGetLocationsQuery, EfGetLocationsQuery>();
            services.AddTransient<IAddStatusCommand, EfAddStatusCommand>();
            services.AddTransient<AddStatusDTOValidator>();
            services.AddTransient<IUpdateStatusCommand, EfUpdateStatusCommand>();
            services.AddTransient<UpdateStatusDTOValidator>();
            services.AddTransient<IDeleteStatusCommand, EfDeleteStatusCommand>();
            services.AddTransient<DeleteStatusDTOValidator>();
            services.AddTransient<IGetStatusIdQuery, EfGetStatusIdQuery>();
            services.AddTransient<IGetStatusQuery, EfGetStatusQuery>();
            services.AddTransient<IAddPhotoCommand, EfAddPhotoCommand>();
            services.AddTransient<AddPhotoDTOValidator>();
            services.AddTransient<IUpdatePhotoCommand, EfUpdatePhotoCommand>();
            services.AddTransient<UpdatePhotoDTOValidator>();
            services.AddTransient<IDeletePhotoCommand, EfDeletePhotoCommand>();
            services.AddTransient<DeletePhotoDTOValidator>();
            services.AddTransient<IGetPhotoQuery, EfGetPhotoQuery>();
            services.AddTransient<IGetPhotosQuery, EfGetPhotosQuery>();
            services.AddTransient<IAddCoachCommand, EfAddCoachCommand>();
            services.AddTransient<AddCoachDTOValidator>();
            services.AddTransient<IUpdateCoachCommand, EfUpdateCoachCommand>();
            services.AddTransient<UpdateCoachDTOValidator>();
            services.AddTransient<IDeleteCoachCommand, EfDeleteCoachCommand>();
            services.AddTransient<DeleteCoachDTOValidator>();
            services.AddTransient<IGetCoachQuery, EfGetCoachQuery>();
            services.AddTransient<IGetCoachsQuery, EfGetCoachsQuery>();
            services.AddTransient<IAddTrainingCommand, EfAddTrainingCommand>();
            services.AddTransient<AddTrainingDTOValidator>();
            services.AddTransient<IUpdateTrainingCommand, EfUpdateTrainingCommand>();
            services.AddTransient<UpdateTrainingDTOValidator>();
            services.AddTransient<IDeleteTrainingCommand, EfDeleteTrainingCommand>();
            services.AddTransient<DeleteTrainingDTOValidator>();
            services.AddTransient<IGetTrainingQuery, EfGetTrainingQuery>();
            services.AddTransient<IGetTrainingsQuery, EfGetTrainingsQuery>();
            services.AddTransient<IAddCoachTrainingCommand, EfAddCoachTrainingCommand>();
            services.AddTransient<AddCoachTrainingDTOValidator>();
            services.AddTransient<IUpdateCoachTrainingCommand, EfUpdateCoachTrainingCommand>();
            services.AddTransient<UpdateCoachTrainingDTOValidator>();
            services.AddTransient<IDeleteCoachTrainingCommand, EfDeleteCoachTrainingCommand>();
            services.AddTransient<DeleteCoachTrainingDTOValidator>();
            services.AddTransient<IGetCoachTrainingQuery, EfGetCoachTrainingQuery>();
            services.AddTransient<IGetCoachTrainingsQuery, EfGetCoachTrainingsQuery>();
            services.AddTransient<IAddAppointmentCommand, EfAddAppointmentCommand>();
            services.AddTransient<AddAppointmentDTOValidator>();
            services.AddTransient<IUpdateAppointmentCommand, EfUpdateAppointmentCommand>();
            services.AddTransient<UpdateAppointmentDTOValidator>();
            services.AddTransient<IDeleteAppointmentCommand, EfDeleteAppointmentCommand>();
            services.AddTransient<DeleteAppointmentDTOValidator>();
            services.AddTransient<IGetAppointmentQuery, EfGetAppointmentQuery>();
            services.AddTransient<IGetAppointmentsQuery, EfGetAppointmentsQuery>();
            services.AddTransient<IAddGymCommand, EfAddGymCommand>();
            services.AddTransient<AddGymDTOValidator>();
            services.AddTransient<IUpdateGymCommand, EfUpdateGymCommand>();
            services.AddTransient<UpdateGymDTOValidator>();
            services.AddTransient<IDeleteGymCommand, EfDeleteGymCommand>();
            services.AddTransient<DeleteGymDTOValidator>();
            services.AddTransient<IGetGymQuery, EfGetGymQuery>();
            services.AddTransient<IGetGymsQuery, EfGetGymsQuery>();
            services.AddTransient<IAddReservationCommand, EfAddReservationCommand>();
            services.AddTransient<AddReservationDTOValidator>();
            services.AddTransient<IUpdateReservationCommand, EfUpdateReservationCommand>();
            services.AddTransient<UpdateReservationDTOValidator>();
            services.AddTransient<IDeleteReservationCommand, EfDeleteReservationCommand>();
            services.AddTransient<DeleteReservationDTOValidator>();
            services.AddTransient<IModifyStatusCommand, EfModifyStatusCommand>();
            services.AddTransient<IGetReservationQuery, EfGetReservationQuery>();
            services.AddTransient<IGetReservationsQuery, EfGetReservationsQuery>();
            services.AddTransient<IUserEmailSender, SMTPUserEmailSender>();
            services.AddTransient<IEmailSender, SMTPEmailSender>();

            services.AddTransient<IAddRatingCommand, EfAddRatingCommand>();
            services.AddTransient<RatingValidator>();
            services.AddTransient<IUpdateRatingCommand, EfUpdateRatingCommand>();
            services.AddTransient<IDeleteRatingCommand, EfDeleteRatingCommand>();
            services.AddTransient<IGetRatingQuery, EfGetRatingQuery>();
            services.AddTransient<IGetRatingsQuery, EfGetRatingsQuery>();

            services.AddTransient<IAddGymTrainingCommand, EfAddGymTrainingCommand>();
            services.AddTransient<AddGymTrainingDTOValidator>();
            services.AddTransient<IUpdateGymTrainingCommand, EfUpdateGymTrainingCommand>();
            services.AddTransient<UpdateGymTrainingDTOValidator>();
            services.AddTransient<IDeleteGymTrainingCommand, EfDeleteGymTrainingCommand>();
            services.AddTransient<DeleteGymTrainingDTOValidator>();
            services.AddTransient<IGetGymTrainingQuery, EfGetGymTrainingQuery>();
            services.AddTransient<IGetGymTrainingsQuery, EfGetGymTrainingsQuery>();

            services.AddTransient<IIsLogged, EfIsLogged>();

        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}

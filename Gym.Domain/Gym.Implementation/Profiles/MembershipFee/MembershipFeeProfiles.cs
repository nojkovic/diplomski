using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO.MembershipFee;
using Gym.Domain;

namespace Gym.Implementation.Profiles.MembershipFee
{
    public class MembershipFeeProfiles : Profile
    {
        public MembershipFeeProfiles()
        {
            CreateMap<Domain.MembershipFee, ResponseMembershipFeeDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(u => u.Id))
                .ForMember(x => x.TypeOfMembership, y => y.MapFrom(u => u.TypeOfMembership))
                .ForMember(x => x.Description, y => y.MapFrom(u => u.Description))
                .ForMember(x => x.Price, y => y.MapFrom(u => u.Price));



        }
    }
}

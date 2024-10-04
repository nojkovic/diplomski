﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.MembershipFee;

namespace Gym.Application.UseCases.Queries
{
    public interface IGetMembershipFeeQuery:IQuery<ResponseMembershipFeeDTO,int>
    {
    }
}

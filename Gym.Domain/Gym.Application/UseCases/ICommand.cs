﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.UseCases
{
    public interface ICommand<TData> : IUseCase
    {
        void Execute(TData data);
    }
}
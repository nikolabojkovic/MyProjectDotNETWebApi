﻿using MyProjectWebApiDotNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectWebApiDotNET.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Hero> Heroes { get; }

        void Commit();
    }
}

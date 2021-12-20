﻿using metanitLessions.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metanitLessions.Services
{
    public class CounterService
    {
        protected internal ICounter Counter { get; }

        public CounterService(ICounter counter)
        {
            Counter = counter;
        }

        
    }
}

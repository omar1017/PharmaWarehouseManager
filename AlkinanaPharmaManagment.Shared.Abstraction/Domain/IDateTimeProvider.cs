﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Shared.Abstraction.Domain
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}

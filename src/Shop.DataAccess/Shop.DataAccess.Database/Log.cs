﻿using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Log : EntityBase, ILog
    {
        public int Identifier { get { return ID; } }
    }
}

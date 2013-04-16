using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.ContextFactory.Tests
{
    public partial class Log : ILog
    {
        int ILog.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        DateTime ILog.Date
        {
            get { return Date; }
            set { Date = value; }
        }

        string ILog.Type
        {
            get { return Type; }
            set { Type = value; }
        }

        string ILog.Location
        {
            get { return Location; }
            set { Location = value; }
        }

        string ILog.Message
        {
            get { return Message; }
            set { Message = value; }
        }
    }
}

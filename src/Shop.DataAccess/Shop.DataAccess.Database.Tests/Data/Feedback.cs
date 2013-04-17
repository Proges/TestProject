using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database.Tests
{
    public partial class Feedback : IFeedback
    {
        EntityRef<IUser> IFeedback.User
        {
            get { return new EntityRef<IUser>(User); }
            set { User = (User)value.Entity; }
        }
    }
}

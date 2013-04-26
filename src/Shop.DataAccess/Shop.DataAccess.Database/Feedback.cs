using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Feedback : EntityBase, IFeedback
    {
        public int Identifier { get { return ID; } }

        IUser IFeedback.User
        {
            get { return User; }
            set { User = (User)value; }
        }
    }
}

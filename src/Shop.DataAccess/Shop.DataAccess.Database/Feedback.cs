using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Feedback : IFeedback, IEntity<Feedback>
    {
        public int Identifier { get; set; }

        IUser IFeedback.User
        {
            get { return User; }
            set { User = (User)value; }
        }
    }
}

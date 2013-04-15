using Shop.DataAccess.Database.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Database
{
    public partial class Feedback : IFeedback
    {
        int IFeedback.ID
        {
            get { return ID; }
            set { ID = value; }
        }

        int IFeedback.UserID
        {
            get { return UserID; }
            set { UserID = value; }
        }

        string IFeedback.Topic
        {
            get { return Topic; }
            set { Topic = value; }
        }

        string IFeedback.Text
        {
            get { return Text; }
            set { Text = value; }
        }

        DateTime IFeedback.Date
        {
            get { return Date; }
            set { Date = value; }
        }

        EntityRef<IUser> IFeedback.User
        {
            get { return new EntityRef<IUser>(User); }
            set { User = (User)value.Entity; }
        }
    }
}

using Shop.Business.Data.Contracts;
using Shop.Business.Repository.Contracts;
using Shop.Business.Service.Contracts;
using Shop.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DataAccess.Database.Enumerators;
using Shop.DataAccess.Database;
using System.Data.Linq;
using System.Net.Mail;
using System.Net;

namespace Shop.Business.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;


        public UserService() : this(null)
        {

        }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? Factory.GetRepository<IUserRepository>();
        }

        public IUserBusiness LogIn(string login, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Login == login && u.Password == password);
            return (IUserBusiness)user;
        }

        public IUserBusiness LogOut(IUserBusiness user)
        {
            user = null;
            user.RoleID = (int)UserRole.Guest;
            return user;
        }

        public IUserBusiness Registration(IUserBusiness user)
        {
            _userRepository.Save((User)user);
            return user;
        }

        public void SendPassword(string email)
        {
            NetworkCredential nc = new NetworkCredential("testshopemail@gmail.com", "ppppppppp1");
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = nc;
            SmtpServer.EnableSsl = true;
            mail.From = new MailAddress("testshopemail@gmail.com");
            mail.To.Add(email);

            mail.Subject = "Shop password recovery";
            mail.Body = "Your password: "+_userRepository.GetAll().FirstOrDefault(user => user.Person.Email == email).Password;

            SmtpServer.Send(mail);
        }
    }
}

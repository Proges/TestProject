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
using Shop.Business.Data;
using Shop.DataAccess.Database.Enumerators;
using System.Text.RegularExpressions;

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

        public IUserBusiness LogOut()
        {
            var user = Factory.GetComponent<IUserBusiness>();
            user.RoleID = (int)UserRole.Guest;
            return user;
        }

        public IUserBusiness Registration(IUserBusiness user, int roleID)
        {
            if (user != null && user.RoleID == (int)UserRole.Guest && user.Login.Count() > 6 && user.Password.Count() > 8 && roleID>=(int)UserRole.Admin && roleID <= (int)UserRole.Guest)
            {
                var person = user.Person;
                var emailPattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

                if (person != null && person.Address != null && Regex.IsMatch(person.Email, emailPattern) &&
                    !string.IsNullOrWhiteSpace(person.Name) && !string.IsNullOrWhiteSpace(person.SecondName))
                {
                    var address = person.Address;

                    if (address.City != null && !string.IsNullOrWhiteSpace(address.House) && !string.IsNullOrWhiteSpace(address.Street))
                    {
                        user.RoleID = roleID;
                        _userRepository.Save((UserBusiness)user);
                    }
                }
            }
            return user;
        }

        public bool SendPassword(string email)
        {
            var emailService = Factory.GetComponent<IEmailService>();
            var currUser =  _userRepository.GetAll().FirstOrDefault(user => user.Person.Email == email);

            if (currUser != null)
            {
                string title = "Shop password recovery";
                string body = "Your password: " + currUser.Password;
                string userEmail = "testshopemail@gmail.com";
                emailService.SendEmail(userEmail, title, body);
                return true;
            }
            return false;
        }
    }
}

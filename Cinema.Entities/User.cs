using Cinema.Helpers;
using System;

namespace Cinema.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value.GetSHA512Code();
            }
        }

        public string Role { get; set; }

        public DateTime Birthday { get; set; }
    }
}

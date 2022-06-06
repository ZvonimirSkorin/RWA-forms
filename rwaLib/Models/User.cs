using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Models
{
    [Serializable]
    public class User
    {
        private const char DELIMITER = '|';

        public string FName { get; set; }
        public string LName { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        internal string FormatForFileLine() => $"{FName}{DELIMITER}{LName}{DELIMITER}{City}{DELIMITER}{Username}{DELIMITER}{Password}{Environment.NewLine}";

        internal static User ParseFromFileLine(string line)
        {
            string[] details = line.Split(DELIMITER);
            return new User
            {
                FName = details[0],
                LName = details.Length > 1 ? details[1] : string.Empty,
                City = details.Length > 2 ? details[2] : string.Empty,
                Username = details.Length > 3 ? details[3] : string.Empty,
                Password = details.Length > 4 ? details[4] : string.Empty,
            };
        }

        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string fName, string lName, string city, string username, string password)
        {
            FName = fName;
            LName = lName;
            City = city;
            Username = username;
            Password = password;
        }
    }
}

using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Dal
{
    public class FileRepo : IRepo
    {
        private static string DIR = new FileInfo(AppDomain.CurrentDomain.BaseDirectory).Directory.Parent.FullName+@"\data";
        private static string PATH = DIR + @"\user.txt";

        public FileRepo() => CreateFileIfNotExists();

        private void CreateFileIfNotExists()
        {
            Directory.CreateDirectory(DIR);
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public IList<User> LoadUsers()
        {
            IList<User> people = new List<User>();
            string[] lines = File.ReadAllLines(PATH);
            lines.ToList().ForEach(line => people.Add(User.ParseFromFileLine(line)));
            return people;
        }

        public void SaveUser(User user) => File.AppendAllText(PATH, user.FormatForFileLine());
    }
}

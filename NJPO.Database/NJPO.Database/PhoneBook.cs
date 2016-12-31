using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJPO.Database
{
    public class PhoneBook
    {
        DBConnector _database;

        public PhoneBook()
        {
            _database = DBConnector.Instance;
        }

        public List<Person> GetBook()
        {
            var persons = _database.Query("SELECT * FROM PhoneBook");
            List<Person> list = new List<Person>();

            while (persons.Read())
            {
                var person = new Person
                {
                    ID = int.Parse(persons["ID"].ToString()),
                    Name = persons["Name"].ToString(),
                    Surname = persons["Surname"].ToString(),
                    Phone = persons["Phone"].ToString()
                };

                list.Add(person);
            }

            persons.Close();

            return list;
        }

        public bool AddPerson(Person person)
        {
            var lastPerson = GetBook().OrderBy(x => x.ID).LastOrDefault();
            int id;

            if (lastPerson != null)
            {
                id = lastPerson.ID;
                id++;
            }
            else
            {
                id = 1;
            }

            var result = _database.NonQuery($"INSERT INTO PhoneBook VALUES ({id}, '{person.Name}', '{person.Surname}', '{person.Phone}')");

            return result > 0 ? true : false;
        }

        public bool UpdatePerson(Person person)
        {
            var result = _database.NonQuery($"UPDATE PhoneBook SET Name = '{person.Name}', Surname = '{person.Surname}', Phone = '{person.Phone}' WHERE Id = {person.ID}");

            return result > 0 ? true : false;
        }

        public bool DeletePerson(int id)
        {
            var result = _database.NonQuery($"DELETE FROM PhoneBook WHERE Id = {id}");

            return result > 0 ? true : false;
        }
    }
}

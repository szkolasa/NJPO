using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace NJPO.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            int selectedOption = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("********** Baza danych **********");
                Console.WriteLine("1) Ksiązka adresowa\n2) Sortowanie dużej ilości danych\n0) Wyjście\n");
                Console.Write("Wybierz opcję: ");

                var input = Console.ReadLine();

                if (int.TryParse(input, out selectedOption))
                {
                    switch (selectedOption)
                    {
                        case 0:
                            break;
                        case 1:
                            AddressBook();
                            break;
                        case 2:
                            BigDataSort();
                            break;
                        default:
                            Console.WriteLine("Nie rozumiem polecenia!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Nie rozumiem polecenia!");
                }

                Console.WriteLine("Naciśnij enter aby kontynuować");
                Console.ReadLine();
            } while (selectedOption != 0); 
        }

        public static void AddressBook()
        {
            int selectedOption = -1;
            var book = new PhoneBook();
            bool result;

            do
            {
                Console.Clear();
                Console.WriteLine("********** Książka adresowa **********");
                Console.WriteLine("1) Wyświetl\n2) Dodaj\n3) Usuń\n4) Aktualizuj\n0) Wyjście\n");
                Console.Write("Wybierz opcję: ");

                var input = Console.ReadLine();

                if (int.TryParse(input, out selectedOption))
                {
                    switch (selectedOption)
                    {
                        case 0:
                            break;
                        case 1:
                            var persons = book.GetBook();

                            foreach (var item in persons)
                            {
                                Console.WriteLine($"{item.ID}\t{item.Name}\t{item.Surname}\t{item.Phone}");
                            }

                            break;
                        case 2:
                            Console.Write("Imię: ");
                            var name = Console.ReadLine();

                            Console.Write("Nazwisko: ");
                            var surname = Console.ReadLine();

                            Console.Write("Numer telefonu: ");
                            var phone = Console.ReadLine();

                            var person = new Person
                            {
                                Name = name,
                                Surname = surname,
                                Phone = phone
                            };

                            result = book.AddPerson(person);

                            if (result)
                            {
                                Console.WriteLine("Dodanie kontaktu zakończone sukcesem");
                            }
                            else
                            {
                                Console.WriteLine("Nie udało się dodać kontaktu");
                            }

                            break;

                        case 3:
                            Console.Write("Podaj ID osoby do usunięcia: ");
                            var id = Console.ReadLine();

                            int personId;

                            if (int.TryParse(id, out personId))
                            {
                                result = book.DeletePerson(personId);

                                if (result)
                                {
                                    Console.WriteLine("Usunięcie kontaktu zakończone sukcesem");
                                }
                                else
                                {
                                    Console.WriteLine("Nie udało się usunąć kontaktu");
                                }
                            }

                            break;
                        case 4:
                            Console.Write("Podaj ID osoby do aktualizacji: ");
                            var updateId = Console.ReadLine();

                            int personUpdateId;

                            if (int.TryParse(updateId, out personUpdateId))
                            {
                                var personToUpdate = book.GetBook().Where(x => x.ID == personUpdateId).FirstOrDefault();

                                if (personToUpdate != null)
                                {
                                    Console.Write($"Imię ({personToUpdate.Name}): ");
                                    var nameToUpdate = Console.ReadLine();

                                    Console.Write($"Nazwisko ({personToUpdate.Surname}): ");
                                    var surnameToUpdate = Console.ReadLine();

                                    Console.Write($"Telefon ({personToUpdate.Phone}): ");
                                    var phoneToUpdate = Console.ReadLine();

                                    if (!string.IsNullOrEmpty(nameToUpdate))
                                    {
                                        personToUpdate.Name = nameToUpdate;
                                    }

                                    if (!string.IsNullOrEmpty(surnameToUpdate))
                                    {
                                        personToUpdate.Surname = surnameToUpdate;
                                    }

                                    if (!string.IsNullOrEmpty(phoneToUpdate))
                                    {
                                        personToUpdate.Phone = phoneToUpdate;
                                    }

                                    book.UpdatePerson(personToUpdate);
                                }
                                else
                                {
                                    Console.WriteLine("Nie znaleziono osoby o podanym ID!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Podana wartość nie jest poprawna!");
                            }

                            break;
                        default:
                            Console.WriteLine("Nie rozumiem polecenia!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Nie rozumiem polecenia!");
                }

                if (selectedOption != 0)
                {
                    Console.WriteLine("Naciśnij enter aby kontynuować");
                    Console.ReadLine();
                }
            } while (selectedOption != 0);
        }

        public static void BigDataSort()
        {
            Console.Clear();
            Console.WriteLine("********** Sortowanie dużej ilości danych **********");

            var connection = DBConnector.Instance;

            var data = connection.Query("SELECT * FROM BigData");

            if (!data.HasRows)
            {
                Random rand = new Random();

                for (long i = 1; i < long.MaxValue; i++)
                {
                    connection.NonQuery($"INSERT INTO BigData VALUES ({i}, {rand.Next()})");
                }
            }

            data.Close();

            data = connection.Query("SELECT * FROM BigData");

            var list = new List<BigData>();

            while (data.Read())
            {
                var item = new BigData
                {
                    ID = long.Parse(data["Id"].ToString()),
                    Data = long.Parse(data["Data"].ToString())
                };

                list.Add(item);
            }

            data.Close();

            var start = DateTime.Now;

            list.OrderBy(x => x.Data);

            var end = DateTime.Now;

            var difference = end.Subtract(start);

            Console.WriteLine($"Czas sortowania za pomocą LINQ: {difference.Minutes}:{difference.Seconds}.{difference.Milliseconds}");

            start = DateTime.Now;

            var set = connection.Query("SELECT * FROM BigData ORDER BY Data");
            set.Close();

            end = DateTime.Now;

            Console.WriteLine($"Czas sortowania za pomocą bazy danych: {difference.Minutes}:{difference.Seconds}.{difference.Milliseconds}");
        }
    }
}

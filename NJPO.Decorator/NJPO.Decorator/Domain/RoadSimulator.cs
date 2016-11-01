using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NJPO.Decorator.Abstract;
using NJPO.Decorator.Concrete;
using NJPO.Decorator.Decorators;

namespace NJPO.Decorator.Domain
{
    public class RoadSimulator
    {
        public RoadSimulator()
        {
            Console.WindowHeight = 88;
            Console.WindowWidth = 80;

            var roadUsers = new List<RoadUser>(new RoadUser[]
            {
                new Pedestrian(),
                new Pedestrian(),
                new Pedestrian(),
                new Driver(),
                new Cyclist(),
                new Cyclist()
            });

            bool collision = false;

            Random r = new Random();

            foreach (var user in roadUsers)
            {
                do
                {
                    user.XPosition = r.Next(Console.WindowWidth);
                    user.YPosition = r.Next(Console.WindowHeight);
                } while (roadUsers.Where(u => u.XPosition == user.XPosition && u.YPosition == user.YPosition).ToList().Count > 1);
            }

            do
            {
                Console.Clear();
                Console.CursorTop = 0;
                Console.CursorLeft = 0;

                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    for (int j = 0; j < Console.WindowWidth; j++)
                    {
                        List<RoadUser> users = roadUsers.Where(u => u.XPosition == i && u.YPosition == j).ToList();

                        if (users.Count > 1)
                        {
                            collision = true;
                            Console.Write("X");
                        }
                        else
                        {
                            RoadUser user = users.FirstOrDefault();
                            Console.Write(user?.Symbol().ToString() ?? " ");
                        }
                    }
                }

                for (int i = 0; i < roadUsers.Count; i++)
                {
                    RoadUser user = roadUsers[i];

                    user.Move();

                    if (user.Symbol() == 'P')
                    {
                        var chance = r.Next(101);

                        if (chance >= 90)
                        {
                            roadUsers[i] = new PedestrainToCyclistDecorator(user);
                            Debug.WriteLine($"Pedestrian became cyclist");
                        }

                        if (chance <= 10)
                        {
                            roadUsers[i] = new PedestrianToDriverDecorator(user);
                            Debug.WriteLine($"Pedestrian became driver");
                        }
                    }
                    else if (user.Symbol() == 'C')
                    {
                        var chance = r.Next(101);

                        if (chance >= 85)
                        {
                            roadUsers[i] = new CyclistToPedestrianDecorator(user);
                            Debug.WriteLine($"Cyclist became pedestrian");
                        }
                    }
                    else if (user.Symbol() == 'D')
                    {
                        var chance = r.Next(101);

                        if (chance >= 95)
                        {
                            roadUsers[i] = new DriverToPedestrianDecorator(user);
                            Debug.WriteLine($"Driver became pedestrian");
                        }
                    }
                    
                }

                Console.ReadLine();

                if (collision)
                {
                    Console.WriteLine("Kolizja! (X - miejsce kolizji)");
                }
            } while (!collision);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Factory.Abstract;

namespace NJPO.Factory.Domain
{
    public class ContactPage : WebPage
    {
        public override string GeneratePage()
        {
            var names = new[] { "John", "Peter", "Karl" };
            var surnames = new[] { "Nowak", "Kowalski" };
            var cities = new[] { "Warszawa", "Łódź", "Kraków" };
            var streets = new[] { "Kościuszki", "Hallera", "Sucha" };

            var html = new StringBuilder(base.GeneratePage());
            var rand = new Random();

            html.Append(@"<title>Contact page</title>");
            html.Append(@"</head><body>");
            html.Append(@"<p>");

            html.Append($"{names[rand.Next(names.Length)]} {surnames[rand.Next(surnames.Length)]} ul. {streets[rand.Next(streets.Length)]} {rand.Next(250)}, {cities[rand.Next(cities.Length)]}");

            html.Append(@"</p>");
            html.Append(@"</body></html>");

            return html.ToString();
        }
    }
}

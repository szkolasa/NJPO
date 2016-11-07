using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Factory.Abstract;

namespace NJPO.Factory.Domain
{
    public class GalleryPage : WebPage
    {
        public override string GeneratePage()
        {
            var html = new StringBuilder(base.GeneratePage());

            html.Append(@"<title>Gallery page</title>");
            html.Append(@"</head><body>");

            var rand = new Random();
            var images = rand.Next(10);

            for (int i = 0; i < images; i++)
            {
                html.Append($@"<img src=""obrazek.png"" alt=""Obrazek {i}"" width=""400"" height=""400"" /><br />");
            }

            html.Append(@"</body></html>");

            return html.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Factory.Abstract;

namespace NJPO.Factory.Domain
{
    public class NewsPage : WebPage
    {
        public override string GeneratePage()
        {
            var html = new StringBuilder(base.GeneratePage());

            var lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec gravida dignissim turpis at molestie. Praesent a nunc ligula. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Fusce tempus nulla eu metus molestie luctus. Sed facilisis sed orci vitae facilisis. Cras sit amet nisi lacus. Curabitur placerat aliquet euismod.";

            html.Append(@"<title>News page</title>");
            html.Append(@"</head><body>");

            var rand = new Random();
            var articles = rand.Next(10);

            for (int i = 0; i < articles; i++)
            {
                html.Append(@"<h1>Lorem ipsum</h1>");
                html.Append(@"<p>").Append(lorem).Append("</p>");
                html.Append(@"<br />");
            }

            html.Append(@"</body></html>");
            return html.ToString();
        }
    }
}

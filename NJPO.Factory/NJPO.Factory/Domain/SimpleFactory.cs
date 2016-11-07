using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Factory.Abstract;

namespace NJPO.Factory.Domain
{
    public class SimpleFactory
    {
        public WebPage CreateWebPage(WebPageType type)
        {
            switch (type)
            {
                case WebPageType.GalleryPage:
                    return new GalleryPage();
                    break;
                case WebPageType.InformationPage:
                    return new InformationPage();
                    break;
                case WebPageType.ContactPage:
                    return new ContactPage();
                    break;
                case WebPageType.NewsPage:
                    return new NewsPage();
                    break;
                default:
                    throw new Exception("Type does not exist");
                    break;
            }
        }
    }
}

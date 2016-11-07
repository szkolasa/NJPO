using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NJPO.Factory.Abstract
{
    public enum WebPageType
    {
        GalleryPage,
        InformationPage,
        ContactPage,
        NewsPage
    }

    public abstract class WebPage
    {
        public virtual string GeneratePage()
        {
            return new StringBuilder(@"<!DOCTYPE html><html><head><meta charset=""UTF-8"" />").ToString();
        }
    }
}

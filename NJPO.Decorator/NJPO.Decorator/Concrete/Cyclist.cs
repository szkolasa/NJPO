using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Decorator.Abstract;

namespace NJPO.Decorator.Concrete
{
    public class Cyclist : RoadUser
    {
        public override int Speed()
        {
            return 2;
        }

        public override char Symbol()
        {
            return 'C';
        }
    }
}

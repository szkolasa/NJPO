using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Decorator.Abstract;

namespace NJPO.Decorator.Concrete
{
    public class Pedestrian : RoadUser
    {
        public override int Speed()
        {
            return 1;
        }

        public override char Symbol()
        {
            return 'P';
        }
    }
}

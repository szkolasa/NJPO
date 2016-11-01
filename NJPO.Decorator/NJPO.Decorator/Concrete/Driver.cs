using NJPO.Decorator.Abstract;

namespace NJPO.Decorator.Concrete
{
    public class Driver : RoadUser
    {
        public override int Speed()
        {
            return 4;
        }

        public override char Symbol()
        {
            return 'D';
        }
    }
}

using NJPO.Decorator.Abstract;

namespace NJPO.Decorator.Decorators
{
    public class PedestrianToDriverDecorator : RoadUserDecorator
    {
        public PedestrianToDriverDecorator(RoadUser roadUser) : base(roadUser)
        {
        }

        public override int Speed()
        {
            return base.Speed() + 3;
        }

        public override char Symbol()
        {
            return 'D';
        }
    }
}

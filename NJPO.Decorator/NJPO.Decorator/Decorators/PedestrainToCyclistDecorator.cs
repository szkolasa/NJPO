using NJPO.Decorator.Abstract;

namespace NJPO.Decorator.Decorators
{
    public class PedestrainToCyclistDecorator : RoadUserDecorator
    {
        public PedestrainToCyclistDecorator(RoadUser roadUser) : base(roadUser)
        {
        }

        public override int Speed()
        {
            return base.Speed() + 1;
        }

        public override char Symbol()
        {
            return 'C';
        }
    }
}

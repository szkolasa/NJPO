namespace NJPO.Decorator.Abstract
{
    public class RoadUserDecorator : RoadUser
    {
        private RoadUser _roadUser;

        public RoadUserDecorator(RoadUser roadUser)
        {
            _roadUser = roadUser;
            XPosition = roadUser.XPosition;
            YPosition = roadUser.YPosition;
        }

        public override int Speed()
        {
            return _roadUser.Speed();
        }

        public override char Symbol()
        {
            return _roadUser.Symbol();
        }
    }
}

using System;

namespace NJPO.Singleton.Domain
{
    public class Casino
    {
        public static Casino Instance
        {
            get
            {
                return _casino ?? (_casino = new Casino());
            }
        }
        private static Casino _casino;

        public double Money { get; private set; }

        private Casino()
        {
            Money = 2000;
        }

        public void AddMoney(double money)
        {
            Money += money;
        }

        public void TakeMoney(double money)
        {
            if (Money == 0)
            {
                throw new Exception("Jesteś bankrutem!");
            }
            else if ((Money - money) < 0)
            {
                throw new Exception("Nie masz wystarczającej ilości gotówki!");
            }

            Money -= money;
        }
    }
}

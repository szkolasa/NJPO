using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJPO.Singleton.Abstract;
using NJPO.Singleton.Domain;

namespace NJPO.Singleton.Games
{
    public class BlackJack : IGame
    {
        public string Name { get { return "BlackJack"; } }

        public void Play(Casino casino)
        {
            var colors = new List<char>(new [] 
            {
                '\u2660',
                '\u2665',
                '\u2666',
                '\u2663'
            });

            var deck = new List<Card>();


        }
    }
}

using NJPO.Singleton.Domain;

namespace NJPO.Singleton.Abstract
{
    public interface IGame
    {
        string Name { get; }
        void Play(Casino casino);
    }
}

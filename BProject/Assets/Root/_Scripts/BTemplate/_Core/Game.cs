using Root.Services;
using System.Collections;
using Root.Sessions;
using Root.Tools;

namespace Root.Core
{
    public class Game
    {
        public ILocator<IService> ServiceLocator { get; private set; }

        public void Init(ILocator<IService> serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }

        public IEnumerator Run()
        {
            Session.Init(ServiceLocator);

            yield return Session.Run();
        }
    }
}

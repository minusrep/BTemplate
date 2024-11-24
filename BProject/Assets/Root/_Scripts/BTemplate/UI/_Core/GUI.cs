using Root.Tools;
using Root.Services;

namespace Root.UI
{
    public class GUI : IController
    {
        protected ILocator<IService> _services;

        protected ILocator<IController> _controllers;

        public virtual void Init(ILocator<IService> services, ILocator<IController> controllers)
        {
            _services = services;
            
            _controllers = controllers;
        }
    }
}

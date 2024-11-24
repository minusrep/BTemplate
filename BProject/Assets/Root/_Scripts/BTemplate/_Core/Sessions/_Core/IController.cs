using Root.Tools;
using Root.Services;

namespace Root
{
    public interface IController
    {
        void Init(ILocator<IService> services, ILocator<IController> controllers);
    }
}

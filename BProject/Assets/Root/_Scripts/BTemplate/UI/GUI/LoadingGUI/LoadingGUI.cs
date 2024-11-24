using Root.Services;
using Root.Tools;

namespace Root.UI
{
    public class LoadingGUI : GUI
    {
        private UILoadingScreenWindow _loadingScreen;

        public override void Init(ILocator<IService> services, ILocator<IController> controllers)
        {
            base.Init(services, controllers);
            
            _loadingScreen = new UILoadingScreenWindow();
            
            _loadingScreen.Init(services);
        }
    }
}
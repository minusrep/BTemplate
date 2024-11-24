using Root.Services;
using Root.UI;

namespace Root.Sessions
{
    public class LoadingSession : Session
    {
        protected override SceneType Scene => SceneType.Loading;

        protected override void Init()
        {
            var loadingGUI = new LoadingGUI();

            RegisterController<LoadingGUI>(loadingGUI);
        }
    }
}
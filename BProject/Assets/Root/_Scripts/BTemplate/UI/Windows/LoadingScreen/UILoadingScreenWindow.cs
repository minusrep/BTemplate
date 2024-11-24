using Root.Constants;
using Root.Services;
using Root.Tools;
using UnityEngine.UIElements;

namespace Root.UI
{
    public sealed class UILoadingScreenWindow : UIWindow
    {
        public override string Name => "LoadingScreen";

        private UIProgressBar _progressBar;

        private ISceneLoader _sceneLoader;
    
        public override void Init(ILocator<IService> services, IWindowManipulator manipulator = null)
        {
            base.Init(services, manipulator);

            _sceneLoader = services.Get<ISceneLoader>();

            ApplySubscribtions();
        }

        protected override void InitElements()
        {
            _progressBar = new UIProgressBar(_root.Q<VisualElement>(UIConstants.ProgressBar));
        }

        private void ApplySubscribtions()
        {
            _sceneLoader.OnLoadingEvent += (value) =>
            {
                _progressBar.Value = value;
            };
        }
    }
}

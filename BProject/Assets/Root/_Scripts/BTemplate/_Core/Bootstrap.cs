using Root.Services;
using Root.Services.Audio;
using Root.Services.SDK;
using System.Collections;
using Root.Tools;

namespace Root.Core
{
    public class Bootstrap : GameBehavior
    {
        private static Bootstrap _instance;

        private IEnumerator Start()
            => Init();

        private IEnumerator Init()
        {
            var singletonExists = !CreateSingleton();

            if (singletonExists) yield break;

            var services = new Locator<IService>();

            var sceneLoader = InitSceneLoader(services);

            yield return sceneLoader.LoadSceneAsync(SceneType.Bootstrap, false);

            yield return InitSDK(services);

            yield return InitLocalization(services);

            InitAssetsProvider(services);
            
            InitGameBehavior(services);

            InitAudioSystem(services);

            var game = new Game();

            game.Init(services);

            yield return game.Run();
        }

        private bool CreateSingleton()
        {
            if (_instance != null)
            {
                Destroy(gameObject);

                return false;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);

            return true;
        }

        private ISceneLoader InitSceneLoader(Locator<IService> services)
        {
            var sceneLoader = new SceneLoader();

            services.Register<ISceneLoader>(sceneLoader);

            return sceneLoader;
        }

        private void InitAssetsProvider(Locator<IService> services)
        {
            var assetsProvider = new AssetsProvider();
            
            services.Register<IAssetsProvider>(assetsProvider);
        }
        
        private void InitGameBehavior(Locator<IService> services)
        {
            services.Register<IUpdater>(this);

            services.Register<ICreator>(this);
            
            services.Register<IRoutineRunner>(this);
            
            services.Register<IGizmos>(this);
        }

        private void InitAudioSystem(Locator<IService> services)
        {
            var audio = new AudioSystem();

            audio.Init(services);

            services.Register<IAudio>(audio);
        }

        private IEnumerator InitSDK(Locator<IService> services)
        {
            var sdk = new SDK();

            yield return sdk.Init();

            services.Register<IAdvertisement>(sdk.Strategy.Advertisement);

            services.Register<IDataHandler>(sdk.Strategy.DataHandler);
        }

        private IEnumerator InitLocalization(Locator<IService> services)
        {
            var localization = new LocalizationSystem();

            yield return localization.Init();

            services.Register<ILocalization>(localization);
        }
    }
}

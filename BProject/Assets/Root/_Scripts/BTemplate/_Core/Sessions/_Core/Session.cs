using System;
using Root.Tools;
using Root.Services;
using System.Collections;
using UnityEngine;

namespace Root.Sessions
{
    public abstract class Session : MonoBehaviour, ISession
    {
        private static event Action<Session> OnSessionChangeEvent;
        
        private static SceneType _defaultScene = SceneType.Game;
        
        private static ISceneLoader _sceneLoader;

        private static ILocator<IService> _services;
        
        private static bool IsInitialized => _services != null;
        
        protected abstract SceneType Scene { get;  }
        
        private Locator<IController> _controllers;
        
        public static void Init(ILocator<IService> services)
        {
            _services = services;
            
            _sceneLoader = _services.Get<ISceneLoader>();

            OnSessionChangeEvent += (session) => session.Init();
        }
        
        public static IEnumerator Run()
        {
            yield return _sceneLoader.LoadSceneAsync(_defaultScene);
        }
        
        private IEnumerator Start()
        {
            if (IsInitialized)
                OnSessionChangeEvent?.Invoke(this);
            
            yield return null;
        }

        protected abstract void Init();

        protected void RegisterController<T>(T controller) where T : IController
        {
            _controllers ??= new Locator<IController>();
            
            controller.Init(_services, _controllers);
            
            _controllers.Register<T>(controller);
        }
    }
}

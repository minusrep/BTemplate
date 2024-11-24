using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Root.Constants;

namespace Root.Services
{
    public sealed class SceneLoader : ISceneLoader
    {
        public event Action OnLoadEvent; 

        public event Action<float> OnLoadingEvent;

        public event Action OnLoadedEvent;
        
        public IEnumerator LoadSceneAsync(SceneType scene, bool delay = true, Action callback = null)
        {
            SceneManager.LoadScene((int) SceneType.Loading);
            
            var index = (int) scene;

            var operation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);

            yield return LoadingRoutine(operation, delay);

            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(index));

            SceneManager.UnloadSceneAsync((int) SceneType.Loading);

            callback?.Invoke();
        }

        private IEnumerator LoadingRoutine(AsyncOperation operation, bool delayFlag)
        {
            OnLoadEvent?.Invoke();
            
            var timer = 0.01f;

            if (delayFlag) timer = ServicesConstants.LoadingDelay;

            var current = timer;

            while (!operation.isDone || current > 0f)
            {
                var progress = delayFlag ? (timer - current) / timer : operation.progress;

                current -= Time.deltaTime;

                OnLoadingEvent?.Invoke(progress);

                yield return null;
            }
            
            OnLoadedEvent?.Invoke();
        }
    }
}

using System;
using System.Collections;
using UnityEngine;

namespace Root.Services
{
    public class GameBehavior : MonoBehaviour, IUpdater, ICreator, IRoutineRunner, IGizmos
    {
        public event Action OnUpdateEvent;

        public event Action OnDrawGizmosEvent;

        private void OnDrawGizmos() 
            => OnDrawGizmosEvent?.Invoke();

        private void Update() 
            => OnUpdateEvent?.Invoke();

        public T Create<T>(T prefab) where T : MonoBehaviour 
            => Instantiate(prefab);

        public void Static(GameObject prefab)
            => DontDestroyOnLoad(prefab);

        public void StartRoutine(IEnumerator routine)
            => StartCoroutine(routine);

        public void StopRoutine(IEnumerator routine)
            => StopCoroutine(routine);
    }
}

using UnityEngine;

namespace Root.Services
{
    public class AssetsProvider : IAssetsProvider
    {
        public T Load<T>(string path) where T : Object
        {
            var founded = Resources.Load<T>(path);

            if (founded == null) LogEmpty(path);

            return founded;
        }

        public T[] LoadAll<T>(string path) where T : Object
        {
            var founded = Resources.LoadAll<T>(path);

            if (founded == null) LogEmpty(path);

            return founded;
        }

        private void LogEmpty(string path)
        {
            Debug.Log($"{path} not found");
        }
    }
}

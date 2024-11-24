using UnityEngine;

namespace Root.Services
{
    public interface IAssetsProvider : IService
    {
        T Load<T>(string path) where T : Object;
        
        T[] LoadAll<T>(string path) where T : Object;
    }
}
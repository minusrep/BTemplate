using System.Collections;

namespace Root.Services
{
    public interface IRoutineRunner : IService
    {
        void StartRoutine(IEnumerator routine);
        
        void StopRoutine(IEnumerator routine);
    }
}
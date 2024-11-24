using System;

namespace Root.Services
{
    public interface IGizmos : IService
    {
        event Action OnDrawGizmosEvent;
    }
}
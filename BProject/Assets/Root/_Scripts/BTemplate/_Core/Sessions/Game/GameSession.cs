using Root.Services;
using UnityEngine;

namespace Root.Sessions
{
    public class GameSession : Session
    {
        protected override SceneType Scene => SceneType.Game;

        protected override void Init()
        {
            Debug.Log("GameSession Init");
        }
    }
}
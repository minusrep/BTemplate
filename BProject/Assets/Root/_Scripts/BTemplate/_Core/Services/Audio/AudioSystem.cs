using Root.Constants;
using Root.Tools;
using UnityEngine;

namespace Root.Services.Audio
{
    public class AudioSystem : IAudio, IServiceUser
    {
        public ISource Music => _music;

        public ISource Sounds => _sounds;

        private ICreator _creator;

        private Source _music;

        private Source _sounds;

        private GameObject _root;

        public void Init(ILocator<IService> serviceLocator)
        {
            _creator = serviceLocator.Get<ICreator>();

            CreateRoot();

            _music = CreateSource(AudioConstants.Music);

            _sounds = CreateSource(AudioConstants.Sounds);
        }

        public void PlayOneShot(AudioClip clip) 
            => _sounds.AudioSource.PlayOneShot(clip);

        private void CreateRoot()
        {
            _root = new GameObject(AudioConstants.Audio);

            _creator.Static(_root);
        }

        private Source CreateSource(string name = "")
        {
            var source = new Source();

            source.Init(_root.transform, name);

            return source;
        }
    }
}

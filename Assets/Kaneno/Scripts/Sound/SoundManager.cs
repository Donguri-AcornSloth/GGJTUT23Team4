using System;
using Player;
using UnityEngine;

namespace Sound
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        [Serializable]
        private struct FeedSound
        {
            public int _evolutionID;
            public AudioClip[] feedSEs;
        }

        [SerializeField] private FeedSound[] _feedSounds;

        public static SoundManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            PlayerEvolution.Instance.OnEatFeed.AddListener(() =>
            {
                var evolutionID = PlayerEvolution.Instance.EvolutionID;
                var index = Array.FindIndex(_feedSounds, x => x._evolutionID == evolutionID);

                if (index < 0) return;

                var row = _feedSounds[index];
                var sound = row.feedSEs[UnityEngine.Random.Range(0, row.feedSEs.Length)];

                _audioSource.PlayOneShot(sound);
            });
        }
    }
}
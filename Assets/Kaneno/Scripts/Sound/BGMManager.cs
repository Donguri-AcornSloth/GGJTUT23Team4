using System;
using UnityEngine;

namespace Sound
{
    public class BGMManager : MonoBehaviour
    {
        [Serializable]
        private struct BGMInfo
        {
            public GameManager.StateEnum _state;
            public AudioSource _bgm;
        }

        [SerializeField] private BGMInfo[] _bgms;

        public static BGMManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            GameManager.Instance.OnStateChanged.AddListener(state =>
            {
                for (var i = 0; i < _bgms.Length; i++)
                {
                    var bgm = _bgms[i];
                    bgm._bgm.Stop();
                }

                var index = Array.FindIndex(_bgms, x => x._state == state);
                if (index < 0) return;

                _bgms[index]._bgm.Play();
            });
        }
    }
}
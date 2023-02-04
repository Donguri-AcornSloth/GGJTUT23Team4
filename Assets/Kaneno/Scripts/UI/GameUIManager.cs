using UnityEngine;

namespace UI
{
    public class GameUIManager : MonoBehaviour, IInitialize
    {
        [SerializeField] private GameObject _gameUI;

        private enum State
        {
            None,

            Title,
            Playing,
            GameOver,
            Cleared,
        }

        private State _state = State.None;

        public void Initialize()
        {
            _state = State.Playing;

            OnChangeState(_state);
        }

        private void OnChangeState(State state)
        {
            switch (state)
            {
                case State.Playing:
                    _gameUI.SetActive(true);
                    break;

                default:
                    _gameUI.SetActive(false);
                    break;
            }
        }
    }
}
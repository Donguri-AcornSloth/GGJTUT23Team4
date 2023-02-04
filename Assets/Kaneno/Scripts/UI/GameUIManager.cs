using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUIManager : MonoBehaviour, IInitialize
    {
        [SerializeField] private GameObject _titleUI;
        [SerializeField] private GameObject _gameUI;

        [SerializeField] private Button _startButton;

        private enum State
        {
            None,

            Title,
            Playing,
            GameOver,
            Cleared,
        }

        private State _state = State.None;

        private void Awake()
        {
            _startButton.onClick.AddListener(() => GameManager.Instance.ChangeState(GameManager.StateEnum.Play));

            OnChangeState(State.Title);
        }

        public void Initialize()
        {
            _state = State.Playing;

            OnChangeState(_state);
        }

        private void OnChangeState(State state)
        {
            switch (state)
            {
                case State.Title:
                    _titleUI.SetActive(true);
                    _gameUI.SetActive(false);
                    break;

                case State.Playing:
                    _titleUI.SetActive(false);
                    _gameUI.SetActive(true);
                    break;

                default:
                    _titleUI.SetActive(false);
                    _gameUI.SetActive(false);
                    break;
            }
        }
    }
}
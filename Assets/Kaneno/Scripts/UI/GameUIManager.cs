using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUIManager : MonoBehaviour, IInitialize
    {
        [SerializeField] private GameObject _titleUI;
        [SerializeField] private GameObject _gameUI;
        [SerializeField] private GameObject _gameOverUI;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _titleButton;

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
            _titleButton.onClick.AddListener(() => GameManager.Instance.ChangeState(GameManager.StateEnum.StartMenu));
            
            OnChangeState(GameManager.StateEnum.StartMenu);
            
            GameManager.Instance.OnStateChanged.AddListener(OnChangeState);
        }

        public void Initialize()
        {
            _state = State.Playing;
        }

        private void OnChangeState(GameManager.StateEnum state)
        {
            switch (state)
            {
                case GameManager.StateEnum.StartMenu:
                    _titleUI.SetActive(true);
                    _gameUI.SetActive(false);
                    _gameOverUI.SetActive(false);
                    break;

                case GameManager.StateEnum.Play:
                    _titleUI.SetActive(false);
                    _gameUI.SetActive(true);
                    _gameOverUI.SetActive(false);
                    break;

                case GameManager.StateEnum.GameOver:
                    _titleUI.SetActive(false);
                    _gameUI.SetActive(false);
                    _gameOverUI.SetActive(true);
                    break;

                default:
                    _titleUI.SetActive(false);
                    _gameUI.SetActive(false);
                    _gameOverUI.SetActive(false);
                    break;
            }
        }
    }
}
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
        [SerializeField] private GameObject _clearUI;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button[] _titleButtons;
        [SerializeField] private ClearMovie _clearMovie;
        
        private void Awake()
        {
            _startButton.onClick.AddListener(() => GameManager.Instance.ChangeState(GameManager.StateEnum.Play));

            foreach (var button in _titleButtons)
            {
                button.onClick.AddListener(() => GameManager.Instance.ChangeState(GameManager.StateEnum.StartMenu));
            }

            OnChangeState(GameManager.StateEnum.StartMenu);

            GameManager.Instance.OnStateChanged.AddListener(OnChangeState);
        }

        public void Initialize()
        {
        }

        private void OnChangeState(GameManager.StateEnum state)
        {
            switch (state)
            {
                case GameManager.StateEnum.StartMenu:
                    _titleUI.SetActive(true);
                    _gameUI.SetActive(false);
                    _gameOverUI.SetActive(false);
                    _clearUI.SetActive(false);
                    break;

                case GameManager.StateEnum.Play:
                    _titleUI.SetActive(false);
                    _gameUI.SetActive(true);
                    _gameOverUI.SetActive(false);
                    _clearUI.SetActive(false);
                    break;

                case GameManager.StateEnum.GameOver:
                    _titleUI.SetActive(false);
                    _gameUI.SetActive(false);
                    _gameOverUI.SetActive(true);
                    _clearUI.SetActive(false);
                    break;

                case GameManager.StateEnum.Clear:
                    _titleUI.SetActive(false);
                    _gameUI.SetActive(false);
                    _gameOverUI.SetActive(false);
                    _clearUI.SetActive(true);
                    
                    _clearMovie.PlayEndRoll();
                    
                    break;
            }
        }
    }
}
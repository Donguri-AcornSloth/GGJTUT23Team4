using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ClearMovie : MonoBehaviour
    {
        [SerializeField] private Image _playerImage;

        [SerializeField] private Sprite _playerM;
        [SerializeField] private Sprite _playerZ;
        [SerializeField] private Sprite _playerS;

        /// <summary>
        /// エンドロール再生
        /// </summary>
        public void PlayEndRoll()
        {
            // 種類によって画像差し替え
            switch (PlayerEvolution.Instance.Type)
            {
                case PlayerEvolution.EvolutionType.Carnivorous:
                    _playerImage.sprite = _playerM;
                    break;

                case PlayerEvolution.EvolutionType.Omnivorous:
                    _playerImage.sprite = _playerZ;
                    break;

                case PlayerEvolution.EvolutionType.Herbivore:
                    _playerImage.sprite = _playerS;
                    break;
            }
        }
    }
}
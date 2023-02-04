using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EvolutionGauge : MonoBehaviour
    {
        [SerializeField] private Image _gaugeImage;
        
        private void LateUpdate()
        {
            var percentage = PlayerEvolution.Instance.Percentage;

            _gaugeImage.fillAmount = percentage;
        }
    }
}

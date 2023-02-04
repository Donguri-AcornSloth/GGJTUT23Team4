using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HitPointGauge : MonoBehaviour
    {
        [SerializeField] private Image _gaugeImage;
        
        private void LateUpdate()
        {
            var percentage = PlayerEvolution.Instance.HitPointPercentage;

            _gaugeImage.fillAmount = percentage;
        }
    }
}

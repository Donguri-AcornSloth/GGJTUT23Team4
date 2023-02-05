using UnityEngine;

namespace UI
{
    public class TitleLogoAnimation : MonoBehaviour
    {
        [SerializeField] private Vector2 _amplitude;
        [SerializeField] private float _amplitudeRot;
        [SerializeField] private float _speed;

        private Vector2 _noisePos;
        private Vector3 _initialPosition;

        private void Start()
        {
            _noisePos = new Vector2(
                UnityEngine.Random.Range(0, 256),
                UnityEngine.Random.Range(0, 256)
            );

            _initialPosition = transform.position;
        }

        private void Update()
        {
            // 揺らぎの動き
            _noisePos += Vector2.one * _speed * Time.deltaTime;

            var noiseValue = new Vector2(
                2 * (Mathf.PerlinNoise(_noisePos.x, 0) - 0.5f),
                2 * (Mathf.PerlinNoise(_noisePos.y, 0) - 0.5f)
            );

            transform.position = _initialPosition + (Vector3) Vector2.Scale(noiseValue, _amplitude);
            transform.rotation = Quaternion.Euler(0, 0, noiseValue.x * _amplitudeRot);
        }
    }
}
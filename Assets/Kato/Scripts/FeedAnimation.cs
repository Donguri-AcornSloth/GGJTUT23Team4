using UnityEngine;

public class FeedAnimation : MonoBehaviour
{
    [SerializeField] private float _amplitude;
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
        _noisePos += Vector2.one * _speed * Time.deltaTime;

        var noiseValue = new Vector2(
            2 * (Mathf.PerlinNoise(_noisePos.x, 0) - 0.5f),
            2 * (Mathf.PerlinNoise(_noisePos.y, 0) - 0.5f)
        );

        transform.position = _initialPosition + (Vector3) noiseValue * _amplitude;
        transform.rotation = Quaternion.Euler(0, 0, noiseValue.x * _amplitudeRot);
    }
}
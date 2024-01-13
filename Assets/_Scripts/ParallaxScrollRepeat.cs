using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxScrollRepeat : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;
    [SerializeField] private float scrollSpeed = 1.8f;
    private float _horizontalLength;
    private float _toleranceSpriteSize;
    private Transform _transform;
    private Vector3 _position;
   
    private void Start()
    {
        _transform = transform;
        _toleranceSpriteSize = transform.GetChild(1).transform.localPosition.x;
        _horizontalLength = (_transform.childCount+1) * _toleranceSpriteSize;
        _position = _transform.position;
    }

    private void Update()
    {
        MoveParallaxLayers();

        if (_position.x < -_horizontalLength)
        {
            RepositionParallaxLayer();
        }
    }

    private void MoveParallaxLayers()
    {
        _position = new Vector2(_position.x - (parallaxSpeed * scrollSpeed * Time.deltaTime), _position.y);
        transform.position = _position;
    }

    private void RepositionParallaxLayer()
    {
    
        Vector3 horizontalLengthOffset = new Vector3(_horizontalLength * 2.0f, 0,0);
        _position += horizontalLengthOffset;
        transform.position = _position;
    }
}
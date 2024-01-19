using _Scripts.Manager;
using UnityEngine;

namespace _Scripts.GamePlay
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ParallaxScrollRepeat : MonoBehaviour
    {
        [SerializeField] private float parallaxSpeed;
        private float _horizontalLength;
        private float _toleranceSpriteSize;
        private Transform _transform;
        private Vector3 _position;
        private const float BackgroundMultiplier = 2.0f; 
   
        private void Start()
        {
            
            _transform = transform;
            _toleranceSpriteSize = CalculateSecondChildXPosition();
            _horizontalLength = (transform.childCount + 1) * _toleranceSpriteSize;
            _position = _transform.position;
        }

        private void Update()
        {
            if (!StartGameScene.GetReady)
            {
                if (GameManager.Instance.gameOver)
                {
                    return;
                }
            }

            MoveParallaxLayers();

            if (_position.x < -_horizontalLength)
            {
                RepositionParallaxLayer();
            }
        }

        private void MoveParallaxLayers()
        {
            _position = new Vector2(_position.x - (parallaxSpeed * GameManager.Instance.GetScrollSpeed() * Time.deltaTime), _position.y);
            transform.position = _position;
        }


        private float CalculateSecondChildXPosition()
        {
            if (transform.childCount < 2 || transform.GetChild(1) == null) return 0;
     
            return transform.GetChild(1).localPosition.x;

        }
        
        private void RepositionParallaxLayer()
        {
            
            _position.x += _horizontalLength * BackgroundMultiplier;
            transform.position = _position;
        }
        
        
    }
}
using _Scripts.Manager;
using UnityEngine;

namespace _Scripts.GamePlay.Obstacles
{
    public class PipeScroll : MonoBehaviour
    {
        private Vector2 _position;
        [SerializeField] private float pipesOffset = 25;
        
        private void Start()
        {
            _position = transform.position;
        }
        private void Update()
        {
            if(GameManager.Instance.gameOver)
                return;
            RepositionPipes();
        }

        private void RepositionPipes()
        {
            _position = new Vector2(_position.x -  (Time.deltaTime * GameManager.Instance.GetScrollSpeed() ), _position.y);
            if (_position.x < -pipesOffset)
            {
                _position.x += pipesOffset * 2;
                _position.y = PipeObjectPool.SpawnPipeYPosition;
            }
         
            transform.position = _position;
        }
    }
}

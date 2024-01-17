using _Scripts.GamePlay.Player;
using _Scripts.Manager;
using UnityEngine;

namespace _Scripts.GamePlay.Obstacles
{
    
    public class Pipes : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<BirdController>() != null)
            {
                GameManager.Instance.ScoreIncrement();
            }
        }
        
    }
}

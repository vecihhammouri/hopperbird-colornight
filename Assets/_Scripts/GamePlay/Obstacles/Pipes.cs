using _Scripts.GamePlay.Player;
using _Scripts.Manager;
using UnityEngine;

namespace _Scripts.GamePlay.Obstacles
{
    
    public class Pipes : MonoBehaviour
    {
       [SerializeField] private AudioClip scoreSound;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<BirdController>() == null) return;
            if(GameManager.Instance.gameOver) return;
            AudioManager.Instance.audioSource.PlayOneShot(scoreSound);
            GameManager.Instance.ScoreIncrement();
        }
        
    }
}

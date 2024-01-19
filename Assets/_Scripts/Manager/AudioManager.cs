using UnityEngine;

namespace _Scripts.Manager
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public AudioSource audioSource;
    
        private void Singleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
        }
    
        private void Awake()
        {
            Singleton();
            audioSource = GetComponent<AudioSource>();
        }
    
        public void PlaySound(AudioClip clip)
        {
            if (GameManager.Instance.gameOver) return;

            audioSource.PlayOneShot(clip);
        }
        public void Mute()
        {
            UIManager.Instance.MuteButtonClick();
            audioSource.mute = true;
        }

        public void UnMute()
        {
            UIManager.Instance.UnMuteButton();
            audioSource.mute = false;
        }
        
    }
}

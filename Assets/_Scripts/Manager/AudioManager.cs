using System.Collections;
using UnityEngine;

namespace _Scripts.Manager
{
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
    
        public IEnumerator PlaySound(AudioClip clip)
        {
            if (GameManager.Instance.gameOver) yield break;
            yield return new WaitUntil(() => AudioManager.Instance.audioSource.isPlaying == false);
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

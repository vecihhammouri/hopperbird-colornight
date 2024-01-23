using UnityEngine;

namespace _Scripts.Manager
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public AudioSource audioSource;
        private static byte _audioValue = 1;
        private const string AudioOnOffKey = "AudioOnOff";
        
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

        private void Start()
        {
            _audioValue = LoadAudioSettings();
            if (_audioValue == 1)
            {
                UnMute();
            }
            else
            {
                Mute();
            }
        }
        
        private static void SaveAudioSettings(byte audioStatus)
        {
            _audioValue = audioStatus;
            PlayerPrefs.SetInt(AudioOnOffKey,_audioValue);
            PlayerPrefs.Save();
        }

        private static byte LoadAudioSettings()
        {
            return (byte)PlayerPrefs.GetInt(AudioOnOffKey, _audioValue);
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
            _audioValue = 0;
            SaveAudioSettings(_audioValue);
        }

        public void UnMute()
        {
            UIManager.Instance.UnMuteButtonClick();
            audioSource.mute = false;
            _audioValue = 1;
            SaveAudioSettings(_audioValue);
        }
        
    }
}

using TMPro;
using UnityEngine;

namespace _Scripts.Manager
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        
        public bool getReadyUI;
        
        public GameObject muteButton;
        public GameObject unmuteButton;
        
        #region On Game UI Items

        public GameObject pauseButton;
        public GameObject resumeButton;
        public TMP_Text scoreOnGame;
        
        #endregion
        
        
        public GameObject gameOverObject;
        
        #region Game Over UI Items

        private GameObject _gameOver;
        public GameObject playButton;   
        public GameObject gameOverImage;
        public GameObject scoreImage;
        public TMP_Text gameOverScoreText;
        public TMP_Text bestScoreText;
        public GameObject newImage;
        public GameObject medalGoldImage;
        public GameObject medalSilverImage;

        #endregion

        private void Awake()
        {
            Singleton();
        }
        
        private void Singleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
        }

        public void HideOnGameUI()
        {
            scoreOnGame.text = "";
            pauseButton.SetActive(false);
            resumeButton.SetActive(false);
        }
        public void ShowGameOverUI()
        {
            playButton.SetActive(true);
            gameOverImage.SetActive(true);
            scoreImage.SetActive(true);
        }
        public void HideGameOverUI()
        {
            playButton.SetActive(false);
            gameOverImage.SetActive(false);
            scoreImage.SetActive(false);
            gameOverScoreText.text = "0";//
            bestScoreText.text = "0";//
            newImage.SetActive(false);
            medalGoldImage.SetActive(false);
            medalSilverImage.SetActive(false);
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
        }

        public void PauseButtonClick()
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
        }
        public void ResumeButtonClick()
        {
            resumeButton.SetActive(false);
            pauseButton.SetActive(true);
        }
        
        public void MuteButtonClick()
        {
            muteButton.SetActive(false);
            unmuteButton.SetActive(true);
        }

        public void UnMuteButton()
        {
            unmuteButton.SetActive(false);
            muteButton.SetActive(true);
        }

        
    }
}

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
            NullChecks();
        }


        private void NullChecks()
        {
            if (muteButton == null || unmuteButton == null || pauseButton == null ||
                resumeButton == null || scoreOnGame == null || gameOverObject == null ||
                playButton == null || gameOverImage == null || scoreImage == null ||
                gameOverScoreText == null || bestScoreText == null || newImage == null ||
                medalGoldImage == null || medalSilverImage == null)
            {
                Debug.LogError("One or more UI elements are not assigned!");
            }
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

        public void UnMuteButtonClick()
        {
            unmuteButton.SetActive(false);
            muteButton.SetActive(true);
        }

        
    }
}

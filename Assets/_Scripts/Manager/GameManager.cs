using TMPro;
using UnityEngine;

namespace _Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public bool gameOver;
        private uint _score = 0;
        private static uint _bestScore = 0;
        
        [SerializeField] private float scrollSpeed = 1.8f;
        
        [SerializeField] private GameObject gameOverObject;
        
        private Animator _animator;
        private static readonly int GameOverAnim = Animator.StringToHash("GameOver");
        
        public GameObject muteButton;
        public GameObject unmuteButton;
        
        #region On Game UI Items

        public GameObject pauseButton;
        public GameObject resumeButton;
        public TMP_Text scoreOnGame;
        
        #endregion
        
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
            _animator = gameOverObject.GetComponent<Animator>();
        }
        

        public void StartGame()
        {
            HideGameOverUI();
        }

        private void HideGameOverUI()
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


        public void GameOver()
        {
            gameOver = true;
            NewBestScoreCheck();

            ShowGameOverUI();
            HideOnGameUI();
            
            gameOverScoreText.text = _score.ToString();//
            bestScoreText.text = _bestScore.ToString();//
            ScoreCheckForMedal();
            
            _animator.SetBool(GameOverAnim,true);
        }

        private void HideOnGameUI()
        {
            pauseButton.SetActive(false);
            resumeButton.SetActive(false);
        }

        private void ShowGameOverUI()
        {
            playButton.SetActive(true);
            gameOverImage.SetActive(true);
            scoreImage.SetActive(true);
        }

        private void NewBestScoreCheck()
        {
            if (_score > _bestScore)
            {
                _bestScore = _score;
                newImage.SetActive(true);
            }
        }

        private void ScoreCheckForMedal()
        {
            switch (_score)
            {
                case > 20 and < 50:
                    medalSilverImage.SetActive(true);
                    medalGoldImage.SetActive(false);
                    break;
                case > 50:
                    medalGoldImage.SetActive(false);
                    medalSilverImage.SetActive(false);
                    break;
            }
        }

        public float GetScrollSpeed()
        {
            return scrollSpeed;
        }

        public void ScoreIncrement()
        {
            if (gameOver)
            {
                return;
            }
            _score++;
            scoreOnGame.text = _score.ToString();
        }
        
        
        private void OnApplicationPause(bool pauseStatus)
        {
            //throw new NotImplementedException();
        }
    }
}

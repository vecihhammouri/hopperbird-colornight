using _Scripts.GamePlay.Player;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace _Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameObject player;
        public GameObject pipeManager;
        public bool gameOver;
        public bool gamePaused;
        private uint _score = 0;
        private static uint _bestScore = 0;
        private const string BestScoreKey = "BestScore";
        [SerializeField] private float scrollSpeed = 1.8f;
        private static readonly int GameOverAnim = Animator.StringToHash("GameOver");
        
        [SerializeField] private Camera camera;
        
        [SerializeField] private float cameraShakeTime = 0.1f;
        [SerializeField] private float cameraShakePower = 0.1f;


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
        }

        private void Start()
        {
            _bestScore = (uint)LoadBestScore();
        }

        public void GetReady()
        {
            //UIManager.Instance.HideOnGameUI();
            scrollSpeed = 1.8f;
            UIManager.Instance.audioSettingsPanel.SetActive(false);
            SceneManager.LoadScene(0);


            //UIManager.Instance.HideGameOverUI();*/*/*/* zaten commentti
        }
        public void StartGame()
        {
            //UIManager.Instance.HideGameOverUI();
            UIManager.Instance.audioSettingsPanel.SetActive(true);
            player.SetActive(true);
            pipeManager.SetActive(true);
            UIManager.Instance.onGamePanel.SetActive(true);
            UIManager.Instance.getReadyPanel.SetActive(false);
            
        }
        


        public void GameOver()
        {
            scrollSpeed = 0f;
            if (!gameOver)
            {
                camera.DOShakePosition(cameraShakeTime, cameraShakePower);
            }
            gameOver = true;
            NewBestScoreCheck();

            UIManager.Instance.ShowGameOverUI();
            UIManager.Instance.HideOnGameUI();
            
            UIManager.Instance.gameOverScoreText.text = _score.ToString();
            UIManager.Instance.bestScoreText.text = _bestScore.ToString();
            ScoreCheckForMedal();
            UIManager.Instance.gameOverObject.SetActive(true);
            UIManager.Instance.gameOverObject.GetComponent<Animator>().SetBool(GameOverAnim,true);
        }

        

        private void NewBestScoreCheck()
        {
            if (_score <= _bestScore) return;
            _bestScore = _score;
            SaveBestScore(_bestScore);
            UIManager.Instance.newImage.SetActive(true);
        }

        private static void SaveBestScore(uint bestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey, (int)bestScore);
            PlayerPrefs.Save();
        }
        private static int LoadBestScore()
        {
            return PlayerPrefs.GetInt(BestScoreKey, 0);
        }
        
        private void ScoreCheckForMedal()
        {
            if (_score is >= 20 and < 50)
            {
                UIManager.Instance.medalSilverImage.SetActive(true);
                UIManager.Instance.medalGoldImage.SetActive(false);
            }
            else if (_score > 50)
            {
                UIManager.Instance.medalGoldImage.SetActive(false);
                UIManager.Instance.medalSilverImage.SetActive(false);
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
            UIManager.Instance.scoreOnGame.text = _score.ToString();
        }

        public void PauseGame()
        {
            BirdController.Instance.SetVelocityResume();
            Time.timeScale = 0;
            gamePaused = true;
        }

        public void ResumeGame()
        {
            gamePaused = false;
            Time.timeScale = 1;
        }

        public int GetScore()
        {
            return (int)_score;
        }
        
        private void OnApplicationPause(bool pauseStatus)
        {
            if(gameOver) return;
            PauseGame();
            UIManager.Instance.PauseButtonClick();
        }
        
    }
}

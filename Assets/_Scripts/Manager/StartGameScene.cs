using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Manager
{
    public class StartGameScene : MonoBehaviour
    {
        public static bool GetReady = true;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetReady = false;
                StartGamePlay();
            }
        }

        private static void StartGamePlay()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

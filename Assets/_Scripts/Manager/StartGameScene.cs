/*using UnityEngine;
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
                StartGamePlay();
            }
        }

        private static void StartGamePlay()
        {
            GetReady = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
*/



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
                StartGamePlay();
            }
        }

        private static void StartGamePlay()
        {
            //uimanager getready false, ongame true
            
            GameManager.Instance.StartGame();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}



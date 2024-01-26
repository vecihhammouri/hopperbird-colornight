using UnityEngine;

namespace _Scripts.Manager
{

    public class StartGameScene : MonoBehaviour
    {
        public static readonly bool GetReady = true;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartGamePlay();
            }
        }

        private static void StartGamePlay()
        {
            GameManager.Instance.StartGame();
        }
    }
}



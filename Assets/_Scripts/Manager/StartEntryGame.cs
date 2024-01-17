using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Manager
{
    public class StartEntryGame : MonoBehaviour
    {
        public void StartGetReady()
        {
            SceneManager.LoadScene(0);
        }
    }
}

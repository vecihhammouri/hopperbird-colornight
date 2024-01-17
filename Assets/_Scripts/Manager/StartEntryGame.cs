using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Manager
{
    public class StartEntryGame : MonoBehaviour
    {
        public void StartGetReady()
        {
            UIManager.Instance.getReadyUI = true;
            SceneManager.LoadScene(0);
        }
    }
}

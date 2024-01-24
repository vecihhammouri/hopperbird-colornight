using UnityEngine;

namespace _Scripts.Manager
{
    public class StartEntryGame : MonoBehaviour
    {
        public void StartGetReady()
        {
            //SceneManager.LoadScene(0);

            GameManager.Instance.GetReady();
        }
    }
}

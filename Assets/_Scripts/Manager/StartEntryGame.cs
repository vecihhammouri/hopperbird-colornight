using UnityEngine;

namespace _Scripts.Manager
{
    public class StartEntryGame : MonoBehaviour
    {
        public void StartGetReady()
        {
            GameManager.Instance.GetReady();
        }
    }
}


using System;
using UnityEngine;

namespace _Scripts.Test
{
    public class CrashTest : MonoBehaviour
    {
       private void Update()
       {
           if (Input.GetKeyDown(KeyCode.Alpha0))
               throw new Exception("Crash test worked when pressed 0");
       }
    }
}

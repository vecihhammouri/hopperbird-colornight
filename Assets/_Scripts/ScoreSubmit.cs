using System;
using _Scripts.Manager;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreSubmit : MonoBehaviour
{
   [SerializeField] private TMP_InputField inputName;
   [SerializeField] private TextMeshProUGUI inputCurrentScore;

   public UnityEvent<string, int> submitScoreEvent;


   private void Start()
   {
      inputCurrentScore.text = GameManager.Instance.GetScore().ToString();
   }

   public void SubmitScore()
   {
      inputCurrentScore.text = GameManager.Instance.GetScore().ToString();
      submitScoreEvent.Invoke(inputName.text,int.Parse(inputCurrentScore.text));
   }
}

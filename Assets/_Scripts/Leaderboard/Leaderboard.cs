using System.Collections.Generic;
using Dan.Main;
using TMPro;
using UnityEngine;

namespace _Scripts.Leaderboard
{
   public class Leaderboard : MonoBehaviour
   {
      [SerializeField] private List<TextMeshProUGUI> names;
      [SerializeField] private List<TextMeshProUGUI> scores;

      private readonly string _publicLeaderboardKey = "19418abeb7efb2e87f4705485b7e8ca98b49989bf6336a3249c5d60ff9d0a3e3";

      private void Start()
      {
      
         GetLeaderboard();
      }

      private void GetLeaderboard()
      {
         LeaderboardCreator.GetLeaderboard(_publicLeaderboardKey,((msg) =>
         {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++)
            {
               names[i].text = msg[i].Username;
               scores[i].text = msg[i].Score.ToString();
            }
         
         }));
      }

      public void SetLeaderboardEntry(string username, int score)
      {
         LeaderboardCreator.UploadNewEntry(_publicLeaderboardKey, username, score);
         {
            GetLeaderboard();
         }
      }
   }
}

using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class MainMenuScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leaderboardTop10Text;
    [SerializeField] private TextMeshProUGUI currentRankText;

    public const string LeaderboardKey = "catcher";

    private readonly string _memberID = GameManager.memberID;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLeaderboardTop10();
        UpdateCurrentRank();
    }
    
    void UpdateLeaderboardTop10()
    {
        LootLockerSDKManager.GetScoreList(LeaderboardKey, 10, (response) =>
        {
            if (response.success)
            {
                string leaderboardText = "";
                foreach (var currentEntry in response.items)
                {
                    leaderboardText += currentEntry.rank + ".";
                    leaderboardText += currentEntry.player.name;
                    leaderboardText += " - ";
                    leaderboardText += currentEntry.score;
                    leaderboardText += "\n";
                }
                leaderboardTop10Text.text = leaderboardText;
            }
            else
            {
                Debug.Log("Cant Get Score List");
            }
        });
    }

    void UpdateCurrentRank()
    {
        LootLockerSDKManager.GetMemberRank(LeaderboardKey, _memberID, (response) =>
        {
            if (response.success)
            {
                if (response.rank == 0 || response.score == 0) 
                    currentRankText.text = "No current rank";
                else 
                    currentRankText.text = "Your rank is: #" + response.rank + " - " + response.score;
            }
            else
            {
                Debug.Log("Cant get member rank");
            }
        });
    }
}

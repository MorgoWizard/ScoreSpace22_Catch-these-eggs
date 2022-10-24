using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    public static string memberID;
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully started LootLocker session");
                memberID = response.player_id.ToString();
            }
            else
            {
                Debug.Log("Error starting LootLocker session");
            }
        });
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInput.text, (responseNameSet) =>
        {
            if(responseNameSet.success) Debug.Log("Successfully set player name");
            SceneManager.LoadScene("MainMenu");
        } );
    }
}
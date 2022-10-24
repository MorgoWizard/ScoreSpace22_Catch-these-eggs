using LootLocker.Requests;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LoopManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private float loopTime, step;
    [SerializeField] private int maxHealth;
    [SerializeField] private TextMeshProUGUI score, health;
    private int _currentHealth, _score;
    private float _timer;

    private void Start()
    {
        _currentHealth = maxHealth;
        health.text = "x " + _currentHealth;
        score.text = "Score: " + _score;
    }

    private void FixedUpdate()
    {
        SpeedUp();
        HealthCheck();
    }

    private void HealthCheck()
    {
        if (_currentHealth <= 0)
        {
            string playerName = "";
            LootLockerSDKManager.GetPlayerName((response) =>
            {
                playerName = response.name.ToString();
            });
            LootLockerSDKManager.SubmitScore(GameManager.memberID, _score, MainMenuScore.LeaderboardKey ,playerName,
                (submit) => {if(submit.success) Debug.Log("Score submitted"); });
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void SpeedUp()
    {
        _timer += Time.fixedDeltaTime;

        if (_timer >= loopTime)
        {
            var temp = spawners[Random.Range(0, spawners.Length - 1)];
            if (temp.GetComponent<SpawnObjects>().respawnTime >= 2f)
                temp.GetComponent<SpawnObjects>().respawnTime -= step;
            _timer = 0;
        }
    }

    public void GetScore(int scoreGiven)
    {
        _score += scoreGiven;
        score.text = "Score: " + _score;
    }

    public void GetDamage()
    {
        _currentHealth -= 1;
        health.text = "x " + _currentHealth;
    }
}

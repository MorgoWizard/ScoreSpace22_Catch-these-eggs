using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] egg;
    public float respawnTime;
    void Start()
    {
        StartCoroutine(SpawnWave());
    }
    private void RandomSpawn()
    {
        var check = Random.Range(1,10);
        Instantiate(check == 1 ? egg[1] : egg[0], transform.position, Quaternion.identity); 
    }

    private IEnumerator SpawnWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            RandomSpawn();
        }
    }

}
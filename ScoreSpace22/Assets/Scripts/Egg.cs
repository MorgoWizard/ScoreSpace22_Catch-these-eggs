using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private int score;
    private LoopManager _loopManager;

    private AudioSource _source;
    [SerializeField] private AudioClip[] clips;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = clips[Random.Range(0, clips.Length)];
        _source.Play();
        _loopManager = GameObject.Find("LoopManager").GetComponent<LoopManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _loopManager.GetScore(score);
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Ground"))
        {
            _loopManager.GetDamage();
            Destroy(gameObject);
        }
            
    }
}

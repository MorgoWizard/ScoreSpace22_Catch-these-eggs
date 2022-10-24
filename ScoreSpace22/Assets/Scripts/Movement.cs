using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 _move;
    private Rigidbody2D _playerRb;
    
    private SpriteRenderer _renderer;
    private Animator _animator;
    
    [SerializeField] private float speed;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _playerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _move = new Vector2(Input.GetAxis("Horizontal"), 0);
        PlayerMovement();
        RightFacing();
    }

    private void PlayerMovement()
    {
        Vector2 moveVector = transform.TransformDirection(_move) * speed; //make freeze rotation
        _playerRb.velocity = new Vector2(moveVector.x, _playerRb.velocity.y);
        _animator.SetBool(IsRunning, _playerRb.velocity.x != 0);
    }
    
    private void RightFacing()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _renderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _renderer.flipX = true;
        }
    }
}
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerClimbSpeed = 5f;
    [SerializeField] private float playerJumpSpeed = 5f;

    //cached
    private Rigidbody2D _playerRB;
    private Animator _animator;
    private Collider2D _playerBodyCollider;
    private BoxCollider2D _playerFeetCollider;
    private Vector2 _playerVelocity;
    private Vector3 _playerLocalScale;
    private float _playerStarterGravityScale;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerRB = GetComponent<Rigidbody2D>();
        _playerBodyCollider = GetComponent<Collider2D>();
        _playerFeetCollider = GetComponent<BoxCollider2D>();
        _playerLocalScale = transform.localScale;
        _playerStarterGravityScale = _playerRB.gravityScale;
    }
    private void Update()
    {
        Run();
        Jump();
        FlipSprite();
        ClimbingOnLadder();
    }

    private void Run()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        _playerVelocity.x = horizontalMovement * playerSpeed;
        _playerVelocity.y = _playerRB.velocity.y;
        _playerRB.velocity = _playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(_playerRB.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("IsRunning", playerHasHorizontalSpeed);
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_playerRB.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            _playerLocalScale.x = Mathf.Sign(_playerRB.velocity.x);
            transform.localScale = _playerLocalScale;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _playerVelocity.x = _playerRB.velocity.x;
            _playerVelocity.y = playerJumpSpeed;
            _playerRB.velocity = _playerVelocity;
        }
    }

    private void ClimbingOnLadder()
    {
        if (!_playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            _animator.SetBool("IsClimbing", false);
            _playerRB.gravityScale = _playerStarterGravityScale;
            return;
        }
        _animator.SetBool("IsRunning", false);
        float verticalMovement = Input.GetAxis("Vertical");
        _playerVelocity.x = _playerRB.velocity.x;
        _playerVelocity.y = verticalMovement * playerClimbSpeed;
        _playerRB.velocity = _playerVelocity;
        _playerRB.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(_playerRB.velocity.y) > Mathf.Epsilon;
        _animator.SetBool("IsClimbing", playerHasVerticalSpeed);
    }
}

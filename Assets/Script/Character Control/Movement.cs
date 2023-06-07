using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MovementSpeed = 1f;
    public float JumpForce = 1f;

    private Rigidbody2D _rigidbody;
    public Animator animator;
    [SerializeField] AudioSource jumpingSound;

    //Additional code to help the sliding functional;
    [SerializeField] private SpriteRenderer playerSprite;


    private enum MovementState { idle, running, jumping, falling }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        jumpingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;
        //movement with transition & animation
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            playerSprite.flipX= true;
            state = MovementState.running;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(1, 1);
            state = MovementState.running;
            playerSprite.flipX = false;
        }
        else
        {
            state = MovementState.idle;
        }

        //jumping & animation
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            animator.SetBool("IsJumping", true);
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            jumpingSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("IsJumping", false);
        }
    }
}

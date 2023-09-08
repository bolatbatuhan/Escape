using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rigi;
    Animator anim;

    public float moveSpeed = 4.0f;
    public float jumpForce = 6.0f;
    bool facingRight = true;

    [SerializeField] Transform groundCheck;
    float groundCheckRadius = 1.0f;
    public LayerMask whatIsGround;
    bool isGround = true;

    private void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(rigi.velocity.x < 0 && facingRight) 
        {
            flipFace();
        }else if(rigi.velocity.x > 0 && !facingRight) 
        {
            flipFace();
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround);
    }
    private void FixedUpdate()
    {
        rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigi.velocity.y);
        anim.SetFloat("playerSpeed", Mathf.Abs(rigi.velocity.x));
    }

    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        rigi.AddForce(new Vector2(0f, jumpForce));
    }
}

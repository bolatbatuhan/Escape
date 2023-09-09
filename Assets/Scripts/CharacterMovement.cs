using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rigi;
    Animator anim;

    public float moveSpeed = 4.0f;
    public float jumpForce = 10.0f;
    bool rightingFace = true;
    bool isGround = true;

    [SerializeField] Transform groundCheck;
    float groundCheckRadius = 0.5f;
    public LayerMask whatIsGround;
    
    private void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(rigi.velocity.x < 0 && rightingFace)
        {
            flipFace();
        }else if(rigi.velocity.x > 0 && !rightingFace)
        {
            flipFace();
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            anim.SetTrigger("playerJump");
            
        }

        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround);
    }

    private void FixedUpdate()
    {
        rigi.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*moveSpeed, rigi.velocity.y);
        anim.SetFloat("playerSpeed",Mathf.Abs(rigi.velocity.x));
    }

    void flipFace()
    {
        rightingFace = !rightingFace;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    void Jump()
    {
        rigi.AddForce(new Vector2(0f, jumpForce));
    }
}

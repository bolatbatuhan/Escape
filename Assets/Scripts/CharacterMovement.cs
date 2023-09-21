using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rigi;
    Animator anim;
    public Transform bullet;
    public Transform muzzle;
    public float moveSpeed = 4.0f;
    public float jumpForce = 10.0f;
    private float bulletSpeed = 500.0f;
    bool facingRight = true;
    bool isGround = true;

    [SerializeField] Transform groundCheck;
    float groundCheckRadius = 0.5f;
    public LayerMask whatIsGround;

    private void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        muzzle = transform.GetChild(0);
    }

    private void Update()
    {
        if(rigi.velocity.x < 0 && facingRight){

            flipFace();

        } else if(rigi.velocity.x > 0 && !facingRight){
            flipFace();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
            anim.SetTrigger("playJump");

        }
        if(Input.GetMouseButtonDown(0)){
            Fire1();
        }

        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        
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
    void Fire1()
    {      
        Transform tempBullet;
        
        tempBullet = Instantiate(bullet,muzzle.position,Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        
    }
}

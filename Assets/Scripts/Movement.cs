using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float jumpingPower;
    private bool isFacingRight = true;
    public bool CanMove = true;
    private Animator ani ;
    private float stuck_timer = 0;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        speed= PlayerPrefs.GetInt("Speed");
        jumpingPower = PlayerPrefs.GetInt("Jump");
        ani= GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        ani.SetFloat("Speed",Mathf.Abs(horizontal));

        if(Input.GetButtonDown("Jump") && IsGrounded() && CanMove)
        {
            ani.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && CanMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (!CanMove)
        {
            rb.velocity = Vector2.zero;
            stuck_timer += Time.deltaTime;
            if (stuck_timer > 1.2)
            {
                CanMove= true;
                stuck_timer= 0;
            }
        }

        if(rb.velocity.y==0f && IsGrounded())
        {
            ani.SetBool("IsJumping", false);
        }
        
        Flip();
    }
    
    private void FixedUpdate()
    {
        if (!CanMove)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = new Vector2(horizontal* speed, rb.velocity.y);
        }
       
    }

    public bool IsGrounded() 
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal>0f) 
        { 
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180, 0f);
        }
    }

    public void Immobilaize()
    {
        CanMove= false;
        stuck_timer = 0;
    }
}

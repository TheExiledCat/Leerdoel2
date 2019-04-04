using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float ms;
    public float jump;
    

    private float MoveIn;
    private bool facingRight = true;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    

    
    private Rigidbody2D rb;
    
    float i_grav;
    
    public int movebuffer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        i_grav = GetComponent<Rigidbody2D>().gravityScale;

    }
    void FixedUpdate()
    {

        

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        if (movebuffer == 0 && isGrounded)
        {
            MoveIn = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(MoveIn * ms, rb.velocity.y);
        }else
        if (movebuffer == 0 && !isGrounded)
        {
            MoveIn = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(MoveIn * ms, rb.velocity.y);
        }



    }
    void Update()
    {
        if (movebuffer > 0)
        {
            movebuffer--;


        }
        if ((Input.GetKeyDown(KeyCode.W)) && isGrounded)
        {
            rb.velocity = Vector2.up * jump;
        }
        
        

        if (MoveIn != 0 )
        {
            if(MoveIn > 0  )
            {
                facingRight = true;
            }else if(MoveIn < 0)
            {
                facingRight = false;
            }
        }
        if (!facingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        if (facingRight)
        {

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
    }
}
	
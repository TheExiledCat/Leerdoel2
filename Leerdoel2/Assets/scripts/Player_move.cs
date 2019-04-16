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
    public AudioSource source;
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
        if ((Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.velocity = Vector2.up * jump;
            source.Play();

        }
        if (Input.GetKey(KeyCode.DownArrow)&& isGrounded)
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            transform.position = new Vector3(transform.position.x,-0.25f,transform.position.z);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        if (isGrounded)
        {
            transform.GetChild(1).Rotate(0, 0, -2);
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
	
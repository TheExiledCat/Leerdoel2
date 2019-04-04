using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipers : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    public Transform wallDetection;
    
    float radi = 0.1f;
    public LayerMask whatIsGround;
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

         bool WallInfo = Physics2D.OverlapCircle(wallDetection.position, radi, whatIsGround);
        if(WallInfo == true)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
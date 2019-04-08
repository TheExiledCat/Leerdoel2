using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipers : MonoBehaviour
{
    public GameObject hud;
    public float speed;
    private bool movingRight = true;
    public Transform wallDetection;
    public float  multi;
    float radi = 0.1f;
    public LayerMask whatIsGround;
    private void Update()
    {
        multi = 0.01* hud.points;
        transform.Translate(Vector2.right * speed * Time.deltaTime*multi);

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
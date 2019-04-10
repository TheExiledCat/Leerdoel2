using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipers : MonoBehaviour
{
    public GameObject hud;
    public float speed;
    private bool movingRight = true;
    public Transform wallDetection;
    [SerializeField]
    public float  multi;
    float radi = 0.1f;
    public LayerMask whatIsGround;
    private void Start()
    {
        hud = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        multi = 1+ 0.00001f* hud.GetComponent<Timer>().points;
        transform.Translate(Vector2.right * speed * Time.deltaTime*multi);

        if (transform.position.x <= -10.5f)
        {
            Destroy(gameObject);
        }
        
    }
}
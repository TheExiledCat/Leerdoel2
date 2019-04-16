using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    public GameObject particle;
    public delegate void Combo();
    public static event Combo OnCombo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("hit");
            GetComponent<AudioSource>().Play();
            transform.position = -Vector3.up * 10;
            Instantiate(particle, Vector3.left * 5,Quaternion.identity);
            Invoke("Restart", 2f);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "combo")
        {
            Debug.Log("Combo Hit");
            if (OnCombo != null) OnCombo();
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

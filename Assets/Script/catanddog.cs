using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catanddog : MonoBehaviour
{

    int point = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Renderer ren;

        //void invisible()
        //{
            //ren = GetComponent<Renderer>();
            //ren.enabled = false;
        //}

        //void visible()
        //{
            //ren = GetComponent<Renderer>();
            //ren.enabled = true;
        //}

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
            //invisible();
            point += 1;
            //gameObject.SetActive(true);
            //visible();

        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
            //invisible();
            point -= 1;
            //visible();
            //gameObject.SetActive(true);
        }
        Debug.Log(point);
    }
}

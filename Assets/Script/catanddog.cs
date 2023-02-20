using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catanddog : MonoBehaviour
{

    int point = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            point += 1;
        }
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            point -= 1;
        }
        Debug.Log(point);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catanddog : MonoBehaviour
{
    public float fallSpeed = 10.0f;
    private Vector3 _startingPos;
    public float FallDistance = 5f;

    void Start()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        _startingPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        if (transform.position.y > _startingPos.y + FallDistance)
        {
            transform.position = _startingPos;
        }
    }
   
    //int point = 0;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        

        //if (collision.CompareTag("Enemy"))
        //{
            
            //Destroy(gameObject);
            //gameObject.SetActive(false);
            //invisible();
            //point += 1;
            //gameObject.SetActive(true);
            //visible();

        //}
        //if (collision.CompareTag("Ground"))
        //{
            //Destroy(gameObject);
            //gameObject.SetActive(false);
            //invisible();
            //point -= 1;
            //visible();
            //gameObject.SetActive(true);
        //}
        //Debug.Log(point);
    //}
   
}


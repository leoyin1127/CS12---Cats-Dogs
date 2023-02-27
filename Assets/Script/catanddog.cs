using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catanddog : MonoBehaviour
{
    public float fallspeed = 1.0f; //Falling speed of the game object
    private Vector3 _startingPos; //starting position of the game object
    public float FallDistance = 5f; // Falling distance of the game object

    public float xBounds, yBound; //falling cats and dogs in random x bounds



    void Start()
    {
        transform.Translate(Vector3.down * fallspeed * Time.deltaTime);
        _startingPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * fallspeed * Time.deltaTime); //Enable the game object to fall
        if (transform.position.y > _startingPos.y + FallDistance) //Allow object to return original position when it falls out of the screen
        {
            transform.position = _startingPos;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision) 
    {


        if (collision.CompareTag("Enemy")) //Allow the object to return its original position upon collision with the player
        {
            transform.position = new Vector2(Random.Range(-xBounds, xBounds), yBound);     
            transform.Translate(Vector3.down * fallspeed * Time.deltaTime);
        }
    }   
   
}


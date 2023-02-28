using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public GameObject cat;
    public GameObject dog;
    

    public float xBounds, yBound; //falling cats and dogs in random x bounds and fixed y bound

    void Start()
    {
        StartCoroutine(SpawnGameObject());
    }

    IEnumerator SpawnGameObject()
    {
        yield return new WaitForSeconds(Random.Range(.5f, 1f)); //generate a cat or dog within 0.5 to 1 second

        int randomNumber = Random.Range(1, 10); //generate a random number between 1 to 10

        if (randomNumber <= 5) //if the random number is equal to or smaller than 5, cat will be cloned, or else, dog
            Instantiate(cat,
                new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);
        else
            Instantiate(dog,
                new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);

        StartCoroutine(SpawnGameObject());
    }
    
}

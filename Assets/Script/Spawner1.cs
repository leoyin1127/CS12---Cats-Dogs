using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public GameObject cat;
    public GameObject dog;

    public float xBounds, yBound;
    
    void Start()
    {
        StartCoroutine(SpawnGameObject());
    }

    IEnumerator SpawnGameObject()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));


        if (Random.value <= .6f)
            Instantiate(cat,
                new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);
        else 
            Instantiate(dog,
                new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);

        StartCoroutine(SpawnGameObject());
    }
    
}

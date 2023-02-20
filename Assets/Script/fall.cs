using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour
{
    public GameObject dog1;
    public GameObject cat1;

    public float xBounds, yBound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomGameObject());

    }

    IEnumberator SpawnRandomGameObject()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));

        int randomCatanddog = Random.Range(0, 2);

        if (Random.value <= .6f)
            Instantiate(dog1,
                new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);
        else
            Instantiate(cat1,
                new Vector2(Random.Range(-xBounds, xBounds), yBound), Quaternion.identity);

        StartCoroutine(SpawnRandomGameObject());
    }
}

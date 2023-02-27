using UnityEngine;

public class anotherscore : MonoBehaviour
{
    public GameObject cat; //cat object
    public GameObject dog; //dog object
    public GameObject player; //player
    public int point = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) //when player touch cats or dogs
        {
             // destory the cat or dog that palyer touched
            point += 1;  //get one point
            Debug.Log(point);
        }
    }

    private void Update()
    {   
        
    }
}

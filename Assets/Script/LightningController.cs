using UnityEngine;

public class LightningController : MonoBehaviour
{
    [SerializeField] private float damage; // the amount of damage the lightning inflicts
    [SerializeField] private float minX; // the minimum x position for the lightning to spawn
    [SerializeField] private float maxX; // the maximum x position for the lightning to spawn
    [SerializeField] private float Y; // the Y position for the lightning to spawn
    
    [SerializeField] private float fallSpeed; // the speed at which the lightning falls
    private bool isFalling = false; // whether or not the lightning is currently falling

    private void Update()
    {
        // if the lightning is not currently falling, spawn it at a random x position within the specified range
        // and set isFalling to true
        if (!isFalling)
        {
            float x = Random.Range(minX, maxX);
            transform.position = new Vector2(x, transform.position.y);
            isFalling = true;
        }
        
        // if the lightning is currently falling, move it downwards at a constant speed
        else
        {
            transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
        }

        // if the lightning falls below a certain y position, reset its position and set isFalling to false
        if (transform.position.y < -10f)
        {
            isFalling = false;
            float x = Random.Range(minX, maxX);
            transform.position = new Vector2(x, Y);
        }
    }

    // if the lightning collides with an object tagged as "Enemy", damage that object's health and reset
    // the lightning's position and isFalling status
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            transform.position = new Vector2(0, 20f);
            isFalling = false;
            float x = Random.Range(minX, maxX);
            transform.position = new Vector2(x, Y);

        }
    }

   
}

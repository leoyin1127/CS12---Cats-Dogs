using UnityEngine;

public class LightningController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float minX; // the minimum x position for the lightning to spawn
    [SerializeField] private float maxX; // the maximum x position for the lightning to spawn
    [SerializeField] private float Y; // the Y position for the lightning to spawn
    
    [SerializeField] private float fallSpeed; // the speed at which the lightning falls
    private bool isFalling = false; // whether or not the lightning is currently falling

    private void Update()
    {

        if (!isFalling)
        {
            isFalling = true;
            float x = Random.Range(minX, maxX);
            transform.position = new Vector2(x, transform.position.y);
            gameObject.SetActive(true);
        }
        else
        {
            transform.position -= new Vector3(0, fallSpeed * Time.deltaTime, 0);
        }

        if (transform.position.y < -10f)
        {
            // gameObject.SetActive(false);
            isFalling = false;
            float x = Random.Range(minX, maxX);
            transform.position = new Vector2(x, Y);
        }
    }

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

//  private void OnDisable()
//     {
//         if  (gameObject.SetActive(false))
//         {
//              gameObject.SetActive(true);
//               transform.position = new Vector2(0, 20f); // regenerate the lightning above the screen
//         }
       
//     }
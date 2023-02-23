using UnityEngine;

public class LightningController : MonoBehaviour
{
    [SerializeField] private float damage;

   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}

 // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         collision.gameObject.GetComponent<Health>().TakeDamage(damage);
    //         Destroy(gameObject);
    //     }
    // }
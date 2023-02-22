using UnityEngine;

public class LightningController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("aaaaaaaaaaaaaaaa");

            HeartManager heartManager = FindObjectOfType<HeartManager>();
            if (heartManager != null)
            {
                heartManager.LoseHeart();
            }
        }
    }
}

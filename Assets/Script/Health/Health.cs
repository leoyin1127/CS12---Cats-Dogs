using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth; // the starting health of the object
    public float currentHealth { get; private set; } // the current health of the object, accessible from other scripts

    private void Awake()
    {
        currentHealth = startingHealth; // set the current health to the starting health when the object is created
    }

    // reduce the object's health by the specified amount and ensure that it stays within the range of 0 to the starting health
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        // if the object still has health remaining, play a hurt animation (commented out in this script)
        if (currentHealth > 0)
        {
            // anim.SetTrigger("hurt");
        }   
        // if the object has no health remaining, load the "End" scene
        else
        {
            SceneManager.LoadScene("End");
        }
    }
}

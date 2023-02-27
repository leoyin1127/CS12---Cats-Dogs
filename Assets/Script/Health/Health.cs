using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    // private Animator anim;
    // private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            Application.Quit();
            // if (!dead)
            // {
            //     anim.SetTrigger("die");
            //     GetComponent<PlayerMovement>().enabled = false;
            //     dead = true;
            // }
        }
    }
}    
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth; // a reference to the Health script attached to the player object
    [SerializeField] private Image totalhealthBar; // a reference to the image that represents the total health of the player
    [SerializeField] private Image currenthealthBar; // a reference to the image that represents the current health of the player

    private void Start()
    {
        // set the total health bar fill amount to the player's current health divided by 10 (assuming the starting health is 10)
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
    
    private void Update()
    {
        // set the current health bar fill amount to the player's current health divided by 10 (assuming the starting health is 10)
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}

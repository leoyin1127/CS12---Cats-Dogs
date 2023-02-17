using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // player's movement speed
    public float jumpForce = 10f; // force applied to the player when jumping

    private bool isGrounded = true; // is the player currently on the ground?

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input
        float hInput = Input.GetAxisRaw("Horizontal");

        // Calculate the direction the player should move in
        Vector2 direction = new Vector2(hInput, 0f).normalized;

        // Move the player in the direction
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Check if the player is on the ground and can jump
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Apply the jump force to the player
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Check if the player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     public float speed = 5f; // player's movement speed
//     public float jumpForce = 10f; // force applied to the player when jumping

//     private bool isGrounded = true; // is the player currently on the ground?

//     // Set up the screen boundary
//     private float screenLeft;
//     private float screenRight;

//     private void Start()
//     {
//         // Get the screen boundaries
//         screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x;
//         screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // Get the horizontal input
//         float hInput = Input.GetAxisRaw("Horizontal");

//         // Calculate the direction the player should move in
//         Vector2 direction = new Vector2(hInput, 0f).normalized;

//         // Move the player in the direction
//         transform.position += (Vector3)direction * speed * Time.deltaTime;

//         // Check if the player is on the ground and can jump
//         if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
//         {
//             // Apply the jump force to the player
//             GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
//             isGrounded = false;
//         }

//         // Check if the player is within the screen boundary
//         float xPositions = Mathf.Clamp(transform.position.x, screenLeft, screenRight);
//         transform.position = new Vector3(xPositions, transform.position.y);
//     }

//     // Check if the player is on the ground
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             isGrounded = true;
//         }
//     }
// }

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // player's movement speed
    public float jumpForce = 10f; // force applied to the player when jumping
    public GameObject lightningPrefab; // prefab for the lightning effect
    public int maxHearts = 3; // maximum number of hearts the player can have
    public int startingHearts = 3; // starting number of hearts for the player

    private int currentHearts; // current number of hearts for the player
    private bool isGrounded = true; // is the player currently on the ground?

    // Set up the screen boundary
    private float screenLeft;
    private float screenRight;

    private void Start()
    {
        // Get the screen boundaries
        screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x;

        // Set the starting number of hearts
        currentHearts = startingHearts;
    }

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

        // Check if the player is within the screen boundary
        float xPositions = Mathf.Clamp(transform.position.x, screenLeft, screenRight);
        transform.position = new Vector3(xPositions, transform.position.y);

        // Check if the player has been hit by the lightning
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(lightningPrefab, transform.position, Quaternion.identity);
            if (currentHearts > 0)
            {
                currentHearts--;
            }
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

    // Display the hearts on the screen
    private void OnGUI()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < currentHearts)
            {
                GUI.DrawTexture(new Rect(10 + (i * 30), 10, 24, 24), heartTexture);
            }
            else
            {
                GUI.DrawTexture(new Rect(10 + (i * 30), 10, 24, 24), emptyHeartTexture);
            }
        }
    }
}

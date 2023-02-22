using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // player's movement speed
    public float jumpForce = 10f; // force applied to the player when jumping
    public GameObject heartPrefab; // the heart prefab for displaying lives
    public Transform heartsParent; // the parent transform for the heart objects
    public Vector4 heartsPosition; // the position of the first heart object

    private int lives = 3; // the number of lives the player has
    private bool isGrounded = true; // is the player currently on the ground?

    // Set up the screen boundary
    private float screenLeft;
    private float screenRight;

    private void Start()
    {
        // Get the screen boundaries
        screenLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        // Create heart objects to display player lives
        for (int i = 0; i < lives; i++)
        {
            Vector4 position = heartsPosition + new Vector4(i * 2f, 0f);
            Instantiate(heartPrefab, position, Quaternion.identity, heartsParent);
        }
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
        float xPos = Mathf.Clamp(transform.position.x, screenLeft, screenRight);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    // Check if the player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Lightning"))
        {
            lives--;
            Destroy(collision.gameObject);
            Debug.Log("-1");
            UpdateLives();
        }
    }

    // Update the player's lives display
    private void UpdateLives()
    {
        // Remove all current heart objects
        foreach (Transform heart in heartsParent)
        {
            Destroy(heart.gameObject);
        }

        // Create new heart objects to display the updated lives
        for (int i = 0; i < lives; i++)
        {
            Vector4 position = heartsPosition + new Vector4(i * 2f, 0f);
            Instantiate(heartPrefab, position, Quaternion.identity, heartsParent);
            
            heartPrefab.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }

        // Check if the player has no more lives
        if (lives <= 0)
        {
            // Game over!
            Debug.Log("Game over!");
            // You can add your own game over logic here
        }
    }
}

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

// //     // Check if the player hit by the lightning
// //     private void OnLightningCollisionEnter2D(Collision2D collision_lightning)
// //     {
// //         if (collision_lightning.gameObject.CompareTag("Ligntning"))
// //         {
// //             Hurt = true;
// //         }
// //     }
// }

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Read horizontal keyboard input (A/D or Left/Right arrows).
        float moveX = Input.GetAxis("Horizontal");

        // Move the player left or right.
        transform.Translate(
            Vector2.right * moveX * moveSpeed * Time.deltaTime
        );

        // Check whether the GroundCheck point overlaps an object
        // assigned to the Ground layer.
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            0.2f,
            groundLayer
        );

        // Jump only when the player is touching the Ground layer.
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
        }
    }
}

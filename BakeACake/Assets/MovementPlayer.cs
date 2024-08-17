using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float sprintSpeed = 8.5f;
    public float jumpForce = 8f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float currentMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
        Vector3 move = new Vector3(horizontal, 0f, vertical + 5f);
        Vector3 moveVelocity = move * currentMoveSpeed;
        moveVelocity.y = rb.velocity.y;
        rb.velocity = moveVelocity;
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
        }
    }
}

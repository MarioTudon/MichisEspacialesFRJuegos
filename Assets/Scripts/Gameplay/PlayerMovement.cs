using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rB2D;
    [SerializeField] private float xSpeed = 10;
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private float jumpForce = 10;
    private bool isJumping;
    private float direction = 1;
    private float originalXScale;
    [Header("Check Ground Parameters")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float lenght;
    [SerializeField] private Vector3 offset;
    private Animator playerAnimator;

    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
        originalXScale = transform.localScale.x;
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMovement();
        CheckGround();
    }

    private void HorizontalMovement()
    {
        float horizontalMovement = floatingJoystick.Horizontal;
        rB2D.velocity = new Vector2(horizontalMovement * xSpeed, rB2D.velocity.y);

        playerAnimator.SetFloat("VelX", Mathf.Abs(horizontalMovement));

        if (horizontalMovement * direction < 0f) FlipCharacter();
    }

    private void CheckGround()
    {
        RaycastHit2D isGrounded = Physics2D.Raycast(transform.position + offset, Vector2.down, lenght, whatIsGround);

        playerAnimator.SetBool("IsGrounded", isGrounded);

        Color color = isGrounded ? Color.green : Color.red;
        Debug.DrawRay(transform.position + offset, Vector2.down * lenght, color);

        isJumping = !isGrounded;
    }

    public void Jump()
    {
        if (isJumping) return;
        rB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FlipCharacter()
    {
        direction *= -1;

        Vector3 scale = transform.localScale;
        scale.x = originalXScale * direction;
        transform.localScale = scale;
    }
}

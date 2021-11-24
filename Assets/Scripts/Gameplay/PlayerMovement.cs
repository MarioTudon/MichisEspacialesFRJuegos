using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rB2D;
    [SerializeField] private float xSpeed = 10;
    [SerializeField] private float jumpForce = 10;
    private Animator playerAnimator;
    private float direction = 1;
    private float originalXScale;
    private bool jumping;

    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        originalXScale = transform.localScale.x;
    }

    void Update()
    {
        float horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
        rB2D.velocity = new Vector2(horizontalMovement * xSpeed, rB2D.velocity.y);

        playerAnimator.SetFloat("VelX", Mathf.Abs(horizontalMovement));

        if (horizontalMovement * direction < 0f) FlipCharacter(); 

        if (CrossPlatformInputManager.GetButtonDown("Jump") && !jumping)
        {
            rB2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumping = true;
        }

        playerAnimator.SetBool("Jumping", jumping);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }

    private void FlipCharacter()
    {
        direction *= -1;

        Vector3 scale = transform.localScale;
        scale.x = originalXScale * direction;
        transform.localScale = scale;
    }
}

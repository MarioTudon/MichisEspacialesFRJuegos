using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rB2D;
    [SerializeField] private float xSpeed = 10;
    [SerializeField] private float jumpForce = 10;
    private bool jumping;

    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalMovement = CrossPlatformInputManager.GetAxis("Horizontal");
        rB2D.velocity = new Vector2(horizontalMovement * xSpeed, rB2D.velocity.y);

        if (CrossPlatformInputManager.GetButtonDown("Jump") && !jumping)
        {
            rB2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
    }
}

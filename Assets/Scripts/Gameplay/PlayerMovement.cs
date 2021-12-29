using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rB2D;
    [SerializeField] private float xSpeed = 10;
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private float normalJumpForce = 20;
    [SerializeField] private Animator legsAnimator;
    [SerializeField] private Animator torsoAnimator;
    private bool isJumping;
    private bool isCrouched;
    [HideInInspector] public float direction = 1;
    private float originalXScale;
    [Header("Check Ground Parameters")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float lenght;
    [SerializeField] private Vector3 offset;

    void Start()
    {
        rB2D = GetComponent<Rigidbody2D>();
        originalXScale = transform.localScale.x;
    }

    void Update()
    {
        Crouch();
        HorizontalMovement();
        CheckGround();
        AimBelow(); 
        AimUp();
    }

    private void HorizontalMovement()
    {
        if (floatingJoystick.Horizontal * direction < 0f) FlipCharacter();

        if (isCrouched) return;

        float horizontalMovement = floatingJoystick.Horizontal;

        rB2D.velocity = new Vector2(horizontalMovement * xSpeed, rB2D.velocity.y);

        legsAnimator.SetFloat("VelX", Mathf.Abs(horizontalMovement));
        torsoAnimator.SetFloat("VelX", Mathf.Abs(horizontalMovement));
    }

    private void Crouch()
    {
        float verticalMovement = floatingJoystick.Vertical;

        if(verticalMovement == -1 && !isJumping)
        {
            isCrouched = true;
            rB2D.velocity = Vector2.zero;
        }
        else if(verticalMovement == 0)
        {
            isCrouched = false;
        }

        legsAnimator.SetBool("IsCrouched", isCrouched);

        if (isCrouched) torsoAnimator.ResetTrigger("FrontalShot");
        if (!isCrouched) legsAnimator.ResetTrigger("ShootCrouched");
    }

    private void CheckGround()
    {
        RaycastHit2D isGrounded = Physics2D.Raycast(transform.position + offset, Vector2.down, lenght, whatIsGround);

        legsAnimator.SetBool("IsGrounded", isGrounded);
        torsoAnimator.SetBool("IsGrounded", isGrounded);

        //Para revisar que el rayo tenga la distancia adecuada
        Color color = isGrounded ? Color.green : Color.red;
        Debug.DrawRay(transform.position + offset, Vector2.down * lenght, color);

        isJumping = !isGrounded;
    }

    public void NormalJump()
    {
        if (isJumping) return;

        rB2D.AddForce(Vector2.up * normalJumpForce, ForceMode2D.Impulse);
    }

    private void AimBelow()
    {
        if (isJumping && floatingJoystick.Vertical == -1)
        {
            torsoAnimator.SetBool("AimBelow", true);
            torsoAnimator.ResetTrigger("FrontalShot");
        }

        else if (!isJumping || floatingJoystick.Vertical > -1)
        {
            torsoAnimator.SetBool("AimBelow", false);
            torsoAnimator.ResetTrigger("ShootDown");
        }
    }

    private void AimUp()
    {
        if(floatingJoystick.Vertical == 1)
        {
            torsoAnimator.SetBool("AimUp", true);
            torsoAnimator.ResetTrigger("FrontalShot");
        }
        else
        {
            torsoAnimator.SetBool("AimUp", false);
            torsoAnimator.ResetTrigger("ShootUp");
        }
    }

    public void Shot()
    {
        torsoAnimator.SetTrigger("FrontalShot");
        torsoAnimator.SetTrigger("ShootDown");
        torsoAnimator.SetTrigger("ShootUp");
        legsAnimator.SetTrigger("ShootCrouched");
    }

    private void FlipCharacter()
    {
        direction *= -1;

        Vector3 scale = transform.localScale;
        scale.x = originalXScale * direction;
        transform.localScale = scale;
    }
}

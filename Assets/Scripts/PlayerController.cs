using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        anim.SetBool("IsJumping", !isGrounded);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetBool("IsJumping", true);
            AudioManager.Instance.PlayJump();
        }

        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
    }

    void FixedUpdate()
    {
        anim.SetBool("IsJumping", !isGrounded);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            GameManager.Instance.PlayerDie();
        }

        if (other.CompareTag("Finish"))
        {
            GameManager.Instance.GameComplete();
        }
    }
}
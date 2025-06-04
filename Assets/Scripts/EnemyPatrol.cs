using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 1f;
    public float wallCheckDistance = 0.5f;

    private bool movingRight = true;
    private Rigidbody2D rb;
    private Transform enemyTransform;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTransform = transform;
        originalScale = transform.localScale;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);

        // Ground check — cast a ray diagonally down in the direction of movement
        Vector2 groundRayOrigin = origin + new Vector2(direction.x * 0.5f, 0);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundRayOrigin, Vector2.down, groundCheckDistance, groundLayer);

        // Wall check — cast a ray directly forward
        RaycastHit2D wallInfo = Physics2D.Raycast(origin, direction, wallCheckDistance, groundLayer);

        if (!groundInfo.collider || wallInfo.collider)
        {
            Flip();
        }

        rb.linearVelocity = new Vector2((movingRight ? 1 : -1) * moveSpeed, rb.linearVelocity.y);
    }

    void Flip()
    {
        movingRight = !movingRight;

        // Flip sprite
        Vector3 scale = transform.localScale;
        scale.x = movingRight ? -Mathf.Abs(originalScale.x) : Mathf.Abs(originalScale.x);
        transform.localScale = scale;
    }

    // Optional: show raycasts in the Scene view
    void OnDrawGizmosSelected()
    {
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        Vector2 groundRayOrigin = origin + new Vector2(direction.x * 0.5f, 0);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(groundRayOrigin, groundRayOrigin + Vector2.down * groundCheckDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + direction * wallCheckDistance);
    }
}

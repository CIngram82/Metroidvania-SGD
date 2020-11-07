using UnityEngine;

/// <summary>
/// Used for all ground based enemy movement.
/// Will walk till it hits a wall or platform edge and flips direction
/// Used the OnExitTrigger to know when exiting the groud collider to flip
/// 
/// NOTE: Set up to work with sprites that face right by default
/// </summary>
public class EnemyGroundMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private Rigidbody2D rb2D;
    private Animator anim;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2((transform.localScale.x > 0) ? moveSpeed : -moveSpeed, 0f);
        anim.SetFloat("speed", moveSpeed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-Mathf.Sign(rb2D.velocity.x), 1f);
    }
}

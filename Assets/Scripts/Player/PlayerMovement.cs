using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerMovement;
#pragma warning disable 0649
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
#pragma warning restore 0649
    public int JumpsAllowed { get; set; }

    Rigidbody2D ridg;
    SpriteRenderer rend;
    Animator anim;
    bool canJump;
    int jumpCount = 1;
    float yMovement;
    float moveHorizontal;


    void Start()
    {

        playerMovement = this;
        JumpsAllowed = 1;
        ridg = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        canJump = true;
        speed = 5;
        jumpForce = 6f;
    }

    void Update()
    {
        CheckJumping();
    }

    private void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        ridg.velocity = new Vector2(moveHorizontal * speed, ridg.velocity.y);
        anim.SetFloat("Move", Mathf.Abs(moveHorizontal));
        yMovement = ridg.velocity.y;
        anim.SetFloat("yMovement", yMovement);
        if (yMovement < 0)
        {
            ridg.gravityScale = 2.5f;
        }

        if (moveHorizontal < 0)
        {
            rend.flipX = true;
        }
        else if (moveHorizontal > 0)
        {
            rend.flipX = false;
        }

        if (moveHorizontal == 0 && yMovement == 0)
        {
            anim.SetBool("IsIdle", true);
        }
        else
        {
            anim.SetBool("IsIdle", false);
        }

    }

    void CheckJumping()
    {


        if (Input.GetKey(KeyCode.Space))
        {
            IsGrounded();
            if (IsGrounded())
            {
                anim.SetBool("IsJumping", true);
            }
            else
            {
                anim.SetBool("IsJumping", false);
            }




        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            IsGrounded();
            if (canJump && jumpCount <= JumpsAllowed)
            {
                anim.SetBool("IsJumping", false);
                if (jumpCount == 1)
                {
                    jumpForce = 8.5f;
                    ridg.velocity = new Vector2(ridg.velocity.x, jumpForce);
                    ridg.gravityScale = 1.5f;
                }

                if (jumpCount >= 2)
                {
                    float playerY = ridg.transform.position.y;
                    jumpForce = 8.5f;
                    ridg.velocity = new Vector2(ridg.velocity.x, jumpForce);
                    ridg.gravityScale = 1.5f;
                }

                jumpCount++;
            }
            else
            {
                canJump = false;
            }

        }


    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 1, Color.red, 2f);
        if (hitInfo.collider != null)
        {
            canJump = true;
            ridg.gravityScale = 1f;
            jumpCount = 1;
            return true;
        }
        return false;
    }



}

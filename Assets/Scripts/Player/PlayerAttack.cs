using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack playerAttack;
#pragma warning disable 0649
    [SerializeField] bool hasSword;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask cutLayer;
#pragma warning restore 0649
    Animator anim;
    bool canAttack;
    AudioManager audioManager;

    public bool HasSword { get { return hasSword; } set { hasSword = value; } }


    void Start()
    {
        canAttack = true;
        playerAttack = this;
        hasSword = false;
        anim = GetComponent<Animator>();
        audioManager = AudioManager.AM;
    }

    void Update()
    {
        if (hasSword == true && Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            CheckingForEnemyCollision();
            CheckForVineCollisions();
            anim.SetBool("IsSwinging", true);
            canAttack = false;
            audioManager.Play(audioManager.GetSFX(), "sword_", Random.Range(0, 3));
        }
    }

    private void SwordHit()
    {
        Debug.Log("Swinging");
        anim.SetBool("IsSwinging", false);
        canAttack = true;
    }

    void CheckingForEnemyCollision() // Enemy's have to be set up on an enemy layer for this to work on it.
    {
        Collider2D enemyCollider;
        enemyCollider = Physics2D.OverlapCircle(transform.position, 1.5f, enemyLayer);

        if (enemyCollider != null && enemyCollider.tag == "Boss")
        {
            GoblinBomber.goblinBomber.TakeGoblinDamage();
        }
        else if (enemyCollider != null && enemyCollider.tag == "SmallGoblin")
        {
            Debug.Log("Hitting smallgoblin");
            enemyCollider.GetComponent<SmallGoblin>().TakeSmallGoblinDamage();
        }
        else if (enemyCollider != null)
        {
            Debug.Log(enemyCollider.gameObject.name);
            enemyCollider.gameObject.SetActive(false);
        }

    }

    void CheckForVineCollisions()
    {
        Collider2D VineWallCollider;
        VineWallCollider = Physics2D.OverlapCircle(transform.position, 1.5f, cutLayer);
        if (VineWallCollider != null)
        {
            Debug.Log(VineWallCollider.gameObject.name);
            audioManager.Play(audioManager.GetSFX(), "leaves_");
            VineWallCollider.gameObject.SetActive(false);
        }
    }
}


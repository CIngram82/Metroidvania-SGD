using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 1;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health = Mathf.Max(0,health -damage);
        anim.SetTrigger("isHit");
        anim.SetInteger("Hp", health);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

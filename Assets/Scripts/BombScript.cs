using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    [SerializeField] private LayerMask enemyLayer;
    public void BombExploded()
    {
        Collider2D explodedCollider;
        explodedCollider = Physics2D.OverlapCircle(transform.position, 1.5f, enemyLayer);

        if (explodedCollider != null)
        {
            Debug.Log(explodedCollider.name);
            explodedCollider.gameObject.SetActive(false);
        }
        GetComponent<Animator>().SetBool("hasExploded", true);
        gameObject.SetActive(false);

    }
}

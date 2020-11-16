using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [SerializeField] private LayerMask bombLayer;
    public void BombExploded()
    {
      
        Collider2D bombWallCollider;
        bombWallCollider = Physics2D.OverlapCircle(transform.position, 1.5f, bombLayer);

        if (bombWallCollider != null)
        {
             Debug.Log(bombWallCollider.name);
              bombWallCollider.gameObject.SetActive(false);
        }
        GetComponent<Animator>().SetBool("hasExploded", true);
        gameObject.SetActive(false);

    }
}

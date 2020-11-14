using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public void BombExploded()
    {
        GetComponent<Animator>().SetBool("hasExploded", true);
        gameObject.SetActive(false);

    }
}

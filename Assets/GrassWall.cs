using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassWall : MonoBehaviour
{

    public void Hit()
    {
        Destroy(gameObject);
    }
}

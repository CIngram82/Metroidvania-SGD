using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] GameObject doorRight;
    [SerializeField] GameObject doorLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.transform.position.x > transform.position.x)
            {
                other.transform.Translate(Vector3.left * 3);
            }
            else
            {
                other.transform.Translate(Vector3.right * 3);
            }
            
        }
    }
 

}

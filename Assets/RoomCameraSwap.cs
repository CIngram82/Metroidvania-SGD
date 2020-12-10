using UnityEngine;

public class RoomCameraSwap : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] GameObject virtualCam;
#pragma warning restore 0649


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger) 
        {
            virtualCam.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }
}

using UnityEngine;

public class PlayerBombs : MonoBehaviour
{
    public static PlayerBombs playerBombs;
#pragma warning disable 0649
    [SerializeField] bool hasBomb;
    [SerializeField] GameObject bombPrefab;
#pragma warning restore 0649

    public bool HasBomb{ get { return hasBomb; } set { hasBomb = value; } }

    void Start()
    {
        playerBombs = this;
        hasBomb = false;
    }

 
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J) && hasBomb)
        {
            Vector2 bombPosition = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
            Instantiate(bombPrefab, bombPosition, transform.rotation);
            Debug.Log("canPlace");
            hasBomb = false;
            Invoke("ReloadBomb", 2);
        }
       
    }

   void ReloadBomb()
    {
        hasBomb = true;
    }

}

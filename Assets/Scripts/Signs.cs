using UnityEngine;
using TMPro;

public class Signs : MonoBehaviour
{
    enum SignType { Image, Text }
    [Header("Sign Display Type")]
    [SerializeField] SignType signType;
    [Header("Image")]
    [SerializeField] int spriteIndex;
    [SerializeField] SpriteRenderer signImage;
    [SerializeField] Sprite[] itemSprites;
    [Header("Text")]
    [SerializeField] string text;
    [SerializeField] TextMeshPro signText;


    void Start()
    {
        if (signType == SignType.Image)
        {
            signText.gameObject.SetActive(false);
            signImage.gameObject.SetActive(true);
            signImage.sprite = itemSprites[spriteIndex];
        }
        else
        {
            signImage.gameObject.SetActive(false);
            signText.gameObject.SetActive(true);
            signText.text = text;
        }
    }
}






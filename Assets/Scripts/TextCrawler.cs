using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextCrawler : MonoBehaviour
{
#pragma warning disable 0649
    //[SerializeField] TextMeshProUGUI text;
    [SerializeField] RectTransform text;
    [SerializeField] float scrollSpeed;
#pragma warning restore 0649


    IEnumerator TextCrawlerVert()
    {
        yield return new WaitForEndOfFrame();   // Time for ContentSizeFitter to calculate size.
        float height = text.rect.height;
        float scrollPos = (-height / 2) - 100;

        while (scrollPos < (Screen.height) + (height / 2))
        {
            text.anchoredPosition = Vector3.up * scrollPos;
            scrollPos += scrollSpeed * Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        StartCoroutine(TextCrawlerVert());
    }
}






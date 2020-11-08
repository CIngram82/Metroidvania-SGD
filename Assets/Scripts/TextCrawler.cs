using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextCrawler : MonoBehaviour
{
#pragma warning disable 0649
	[SerializeField] TextMeshProUGUI text;
	[SerializeField] float scrollSpeed;
	[SerializeField] RectTransform textCrawlerTransform;
#pragma warning restore 0649


	IEnumerator TextCrawlerVert()
	{
		float scrollPos = 0.0f;
		float height = text.rectTransform.rect.height;
		Vector3 startPos = textCrawlerTransform.position;

		while (scrollPos < (height * 2) + (Screen.height))
		{
			textCrawlerTransform.position = new Vector3(startPos.x, scrollPos, startPos.z);
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






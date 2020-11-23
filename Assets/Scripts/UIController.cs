using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
	public void OnStart(int index)
	{
		SceneManager.LoadScene(index);
	}
	public void OnHelp()
	{
		SceneManager.LoadScene("Scene_Help");
	}
    public void OnCredits()
    {
        SceneManager.LoadScene("Scene_Credits");
    }
    public void OnMenu()
	{
		SceneManager.LoadScene("Scene_MainMenu");
	}
    public void OnReset()
    {
        Debug.LogWarning("Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnQuit()
    {
        Debug.LogWarning("Quit");
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnReset();
        }
    }
}






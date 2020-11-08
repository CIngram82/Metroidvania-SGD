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
		SceneManager.LoadScene("HelpScene");
	}
    public void OnCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public virtual void OnMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
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






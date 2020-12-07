using UnityEngine;

public class UIGameController : UIController
{
#pragma warning disable 0649
    [Header("Panels")]
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject audioPanel;
#pragma warning restore 0649

    public void OnAudioSettings()
    {
        audioPanel.SetActive(!audioPanel.activeSelf);
    }
    public void OnSettings()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnSettings();
        }
    }
}






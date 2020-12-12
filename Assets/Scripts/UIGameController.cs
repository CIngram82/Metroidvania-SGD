using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameController : UIController
{
#pragma warning disable 0649
    [Header("Image")]
    [SerializeField] Image bombImage;
    [Header("Text")]
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI potionsText;
    [Header("Panels")]
    //[SerializeField] GameObject Panel;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject audioPanel;
#pragma warning restore 0649


    public void UpdateBombImage(bool hasBomb)
    {
        Color color = bombImage.color;
        if (hasBomb)
        {
            color.a = 1.0f;
        }
        else
        {
            color.a = 0.5f;
        }
        bombImage.color = color;
    }
    public void UpdatePotionsText(int amount)
    {
        coinText.text = amount.ToString("00");
    }
    public void UpdateCoinsText(int amount)
    {
        coinText.text = amount.ToString("00");
    }

    public void OnAudioSettings()
    {
        audioPanel.SetActive(!audioPanel.activeSelf);
        if (settingPanel)
            settingPanel?.SetActive(!settingPanel.activeSelf);
    }
    public void OnSettings()
    {
        settingPanel?.SetActive(!settingPanel.activeSelf);
        Time.timeScale = settingPanel.activeSelf ? 0 : 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (audioPanel.activeSelf)
            {
                OnAudioSettings();
                if (settingPanel)
                    OnSettings();
            }
            else if(settingPanel)
            {
                OnSettings();
            }
        }
    }
}






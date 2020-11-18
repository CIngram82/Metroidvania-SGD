using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSlider : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] string sliderName;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI text;
#pragma warning restore 0649


    public void SetSlider(float volume)
    {
        UpdateSlider(volume);
        volume = Mathf.Pow(10, volume / 20);
        slider.value = volume;
    }
    public void UpdateSlider(float volume)
    {
        volume = Mathf.Pow(10, volume / 20);
        Debug.Log("Slider Change");
        text.text = ($" {sliderName}: {Mathf.RoundToInt((volume / slider.maxValue) * 100)}%");
    }
}






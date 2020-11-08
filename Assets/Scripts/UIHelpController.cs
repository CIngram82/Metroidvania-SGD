using UnityEngine;
using UnityEngine.UI;
using Extensions;

public class UIHelpController : UIController
{
#pragma warning disable 0649
	[SerializeField] GameObject[] helpPanels;
	[SerializeField] Button nextButton;
	[SerializeField] Button backButton;
#pragma warning restore 0649
	int panelIndex = 0;


	public void OnNextButtonClick()
	{
		panelIndex++;
		SwitchPanel();

		if (panelIndex == helpPanels.Length - 1)
		{
			nextButton.interactable = false;
		}
		backButton.interactable = true;
	}

	public void OnBackButtonClick()
	{
		panelIndex--;
		SwitchPanel();

		if (panelIndex == 0)
		{
			backButton.interactable = false;
		}
		nextButton.interactable = true;
	}

	void SwitchPanel()
	{
		GameObjectExt.SetAllActive(helpPanels, false);
		helpPanels[panelIndex].SetActive(true);
	}

	void Start()
	{
		SwitchPanel();
		backButton.interactable = false;
	}
}






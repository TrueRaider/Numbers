using UnityEngine.UI;

public class RadioGroup : ButtonsGroup
{
	protected override void SelectAction(int id)
	{
		foreach (Selectable button in this.buttons)
			button.interactable = true;
		if (id < 0 || id >= this.buttons.Count)
			return;
		this.buttons[id].interactable = false;
	}
}

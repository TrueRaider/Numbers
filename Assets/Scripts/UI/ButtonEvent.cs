using UnityEngine.Events;
using UnityEngine.UI;

internal class ButtonEvent
{
    private int _id;
    private ButtonsGroup.ButtonCallback _callback;

    public ButtonEvent(Button button, int id, ButtonsGroup.ButtonCallback callback)
    {
        this._id = id;
        this._callback = callback;
        button.onClick.AddListener(new UnityAction(this.ClickListener));
    }

    private void ClickListener()
    {
        this._callback(this._id);
    }
}

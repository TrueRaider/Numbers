using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class ButtonsGroup : MonoBehaviour
{
    protected int selectedId = -1;
    public List<Button> buttons;
    public int firstPressed;

    private void Start()
    {
        for (int id = 0; id < this.buttons.Count; ++id)
        {
            ButtonEvent buttonEvent = new ButtonEvent(this.buttons[id], id, new ButtonsGroup.ButtonCallback(this.Select));
        }
        if (this.firstPressed < 0 || this.firstPressed >= this.buttons.Count)
            return;
        this.Select(this.firstPressed);
    }

    public virtual void Select(int id)
    {
        bool flag = id != this.selectedId;
        this.selectedId = id;
        this.SelectAction(id);
        if (!flag)
            return;
    }

    protected abstract void SelectAction(int id);

    public int GetSelectedId()
    {
        return this.selectedId;
    }

    public delegate void ButtonCallback(int id);
}


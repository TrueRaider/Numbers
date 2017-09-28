using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParamsButtonsEvents : MonoBehaviour {

    public static UnityEvent x3fieldEvent = new UnityEvent();

    public static UnityEvent x4fieldEvent = new UnityEvent();

    public static UnityEvent x5fieldEvent = new UnityEvent();

    public void x3fieldEventInvoke() {
        x3fieldEvent.Invoke();

    }
    public void x4fieldEventInvoke()
    {
        x4fieldEvent.Invoke();
    }

    public void x5fieldEventInvoke()
    {
        x5fieldEvent.Invoke();
    }
}

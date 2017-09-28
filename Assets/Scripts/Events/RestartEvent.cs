using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RestartEvent : MonoBehaviour {

    public static UnityEvent restartEvent = new UnityEvent();

	private static void ReStart () {

        restartEvent.Invoke();

    }
    public void Restart()
    {
        ReStart();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float time = 0;

    private Text textField;

    private bool inProgress;
	
    void Start()
    {
        textField = transform.GetComponent<Text>();
        RestartEvent.restartEvent.AddListener(Reset);
        textField.text = "0.0";
        inProgress = true;
    }
	void Update () {
        if(inProgress)
        {
            time += Time.deltaTime;
            textField.text = time.ToString("0.0");
        }
    }

    private void Reset()
    {
        time = 0;
        textField.text = "0.0";
        inProgress = true;
    }

    private void Stop()
    {
        inProgress = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementHandler : MonoBehaviour {

    

	void Start () {
        RestartEvent.restartEvent.AddListener(Destroy);
     
    }   

	private void Destroy () {
        Destroy(this.gameObject);
	}
}

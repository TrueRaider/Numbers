using UnityEngine;

public class Preferences : MonoBehaviour {

    private static sizeParam fieldSize = sizeParam.x3;

    //private bool isSound = true;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start () {
        ParamsButtonsEvents.x3fieldEvent.AddListener(()=> { fieldSize = sizeParam.x3; Debug.Log(1); });
        ParamsButtonsEvents.x4fieldEvent.AddListener(() => { fieldSize = sizeParam.x4; Debug.Log(2); });
        ParamsButtonsEvents.x5fieldEvent.AddListener(() => { fieldSize = sizeParam.x5; Debug.Log(3); });
    }

    public static sizeParam GetFieldSize()
    {
        return fieldSize;
    }
	
    public enum sizeParam { x3 = 9,x4 = 16,x5 = 25};
}

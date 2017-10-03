using UnityEngine;

public class FieldElement {
    
    public Vector2 Coordinate;
    public bool isFree;
    public GameObject fieldObject;
    public int numberValue;

    public FieldElement(Vector2 vectorValue, GameObject obj, int intValue)
    {
        numberValue = intValue;
        fieldObject = obj;
        isFree = false;
        Coordinate = vectorValue;
    }
    public FieldElement(Vector2 value)
    {
        Coordinate = value;
        fieldObject = null;
        isFree = true;
    }

    public FieldElement()
    {
    }

    public GameObject FreeField()
    {
        isFree = true;
        return fieldObject;
    }
}

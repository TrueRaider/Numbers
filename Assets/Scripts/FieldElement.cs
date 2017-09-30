using UnityEngine;

public class FieldElement {
    
    public Vector2 Coordinate;
    public bool isFree;
    public GameObject fieldObject;

    public FieldElement(Vector2 value, GameObject obj)
    {
        fieldObject = obj;
        isFree = false;
        Coordinate = value;
    }
    public FieldElement(Vector2 value)
    {
        Coordinate = value;
        fieldObject = null;
        isFree = true;
    }

    public GameObject FreeField()
    {
        isFree = true;
        return fieldObject;
    }
}

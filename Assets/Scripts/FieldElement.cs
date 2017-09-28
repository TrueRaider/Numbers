using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FieldElement {

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

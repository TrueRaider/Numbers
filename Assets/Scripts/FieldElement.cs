using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FieldElement {

    public Vector3 Coordinate;
    public bool isFree;

    public FieldElement(Vector3 value)
    {
        isFree = true;
        Coordinate = value;
    }
}

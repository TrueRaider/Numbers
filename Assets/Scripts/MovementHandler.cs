using System.Collections.Generic;
using UnityEngine;

public static class MovementHandler  {

    public static bool HasXRowFreeField(float xValue)
    {
        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if (field.Coordinate.x == xValue && field.isFree)
            {
                //Debug.Log(field.Coordinate + "\n" + xValue);
                return true;
            }
        }
        return false;
    }
    public static bool HasYRowFreeField(float yValue)
    {
        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if (field.Coordinate.y == yValue && field.isFree)
            {
                //Debug.Log(1);
                return true;
            }
        }
        return false;
    }

    public static bool CanBeMoved(Vector3 verifiableVector)
    {
        if (FieldContainer.GetExtremeBorderPoint1().x > verifiableVector.x && FieldContainer.GetExtremeBorderPoint1().y > verifiableVector.y && FieldContainer.GetExtremeBorderPoint2().x < verifiableVector.x && FieldContainer.GetExtremeBorderPoint2().y < verifiableVector.y)
            return true;
        return false;
    }

    public static Vector3 GetObjectPosition(GameObject obj)
    {
        Vector3 vect = new Vector3();
        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if(field.fieldObject != null && obj.GetInstanceID() == field.fieldObject.GetInstanceID())
            {
                vect = field.Coordinate;
            }
        }
        vect.z = FieldContainer.zValue;
        return vect;
    }

    public static List<FieldElement> GetOsculantObjectsX(Vector2 vect)
    {
        List<FieldElement> newList = new List<FieldElement>();

        Vector2 freeFieldPosition = new Vector2();

        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if (field.isFree) { freeFieldPosition = field.Coordinate; }
        }
        int inc = 0;
        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if (!field.isFree && vect.y == field.Coordinate.y && field.Coordinate.y == freeFieldPosition.y)
            {
                inc++;
                Debug.Log(inc);
            }
        }

        return newList;
    }
    public static List<FieldElement> GetOsculantObjectsY(Vector2 vect)
    {
        List<FieldElement> newList = new List<FieldElement>();

        Vector2 freeFieldPosition = new Vector2();

        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if (field.isFree) { freeFieldPosition = field.Coordinate; }
        }
        int inc = 0;
        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if (!field.isFree && vect.x == field.Coordinate.x && field.Coordinate.x == freeFieldPosition.x)
            {
                inc++;
                Debug.Log(inc);
            }
        }

        return newList;
    }
}

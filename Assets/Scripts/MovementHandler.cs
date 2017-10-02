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

    public static void newHoldPoint(GameObject obj)
    {
        Vector2 originalVectorPosition = FieldContainer.GetFieldElementByGameObject(obj).Coordinate;
        Vector2 newVectorPosition = FieldContainer.GetFieldElementByGameObject(obj).Coordinate;
        float distance = Vector2.Distance(FieldContainer.GetFieldElementByGameObject(obj).Coordinate, (Vector2)obj.transform.localPosition);
        bool isChanged = false;
        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if(field.isFree)
            {
                float tempDistance = Vector2.Distance(field.Coordinate, (Vector2)obj.transform.localPosition);

                if (tempDistance <= distance)
                {
                    newVectorPosition = field.Coordinate;
                    isChanged = true;
                }
            }
            
        }
        FieldContainer.SetNewCoordinates(obj,newVectorPosition);

        if(isChanged)
        {
            FieldContainer.GetFreeFieldElement().Coordinate = originalVectorPosition;
        }

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

    public static List<FieldElement> GetOsculantObjects(Vector2 vect, bool onAxisX, bool onAxisY) //TODO
    {
        List<FieldElement> newList = new List<FieldElement>();

        Vector2 freeFieldPosition = new Vector2();

        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if (field.isFree) { freeFieldPosition = field.Coordinate; }
        }
        foreach (FieldElement field in FieldContainer.GetCollection())
        {
            if(field.Coordinate != vect && onAxisX)
            {
                if (!field.isFree && vect.x == field.Coordinate.x && field.Coordinate.x == freeFieldPosition.x)
                {
                    if ((vect.y > field.Coordinate.y && field.Coordinate.y > freeFieldPosition.y) || (vect.y < field.Coordinate.y && field.Coordinate.y < freeFieldPosition.y))
                        newList.Add(field);
                }
            }
            if (field.Coordinate != vect && onAxisY)
            {
                if (!field.isFree && vect.y == field.Coordinate.y && field.Coordinate.y == freeFieldPosition.y )
                {
                    if((vect.x > field.Coordinate.x && field.Coordinate.x > freeFieldPosition.x) || (vect.x < field.Coordinate.x && field.Coordinate.x < freeFieldPosition.x))
                        newList.Add(field);
                }
            }
        }

        return newList;
    }
}

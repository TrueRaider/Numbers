
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
}

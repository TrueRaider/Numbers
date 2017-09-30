using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldContainer : MonoBehaviour {

    public static List<FieldElement> fields;

    public GameObject prefab;

    private List<Vector2> fieldsCoord3x3;

    private List<Vector2> fieldsCoord4x4;

    void Start () {

        fieldsCoord3x3 = new List<Vector2>();

        fieldsCoord4x4 = new List<Vector2>();

        ArrayCoordCreater(fieldsCoord3x3, "Field 3_");

        ArrayCoordCreater(fieldsCoord4x4, "Field 4_");

        if (fields == null)
        {
            fields = new List<FieldElement>();

            int size = (int)Preferences.GetFieldSize();
            //int size = 16;
            if (size == 9)
                ListFieldCreator(fieldsCoord3x3);
            if (size == 16)
                ListFieldCreator(fieldsCoord4x4);
        }
        
    }
    private void ListFieldCreator(List<Vector2> list)
    {
        System.Random rnd = new System.Random();
        var shuffledList = list.OrderBy(item => rnd.Next());
        int index = rnd.Next(list.Count);
        int inc = 1;
        //Debug.Log(index);
        foreach (Vector2 vect in shuffledList)
        {
            if(inc != index)
            {
                GameObject newObject = (GameObject)Instantiate(prefab);
                newObject.transform.parent = this.transform;
                newObject.transform.localPosition = new Vector3(vect.x, vect.y, 3);
                newObject.GetComponentInChildren<TextMesh>().text = inc.ToString();
                fields.Add(new FieldElement(vect, newObject));
                inc++;
            }
            else
            {
                fields.Add(new FieldElement(vect));
                index = -1;
            }
            
        }

    }

    private void ArrayCoordCreater(List<Vector2> list, string str)
    {
        foreach (Transform child in this.transform)
        {
            if(child.name.Contains(str))
            {
                list.Add(new Vector2(child.localPosition.x, child.localPosition.y));
            }
        }
    }
}

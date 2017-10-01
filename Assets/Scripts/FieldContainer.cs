using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldContainer : MonoBehaviour
{
    private static Vector2 extremeBorderPoint1;
    private static Vector2 extremeBorderPoint2;

    private static List<FieldElement> fields = new List<FieldElement>();

    public GameObject prefab;

    public const float zValue = 3;

    private List<GameObject> elementsArray = new List<GameObject>();

    void Start()
    {
        InitMethod();
        RestartEvent.restartEvent.AddListener(() => { ClearMethod(); InitMethod(); });
    }

    private void ClearMethod()
    {
        Debug.Log("restarted");
    }

    private void InitMethod()
    {
        int size = (int)Preferences.GetFieldSize();
        //int size = 16;
        switch (size)
        {
            case 9:
                ListFieldCreator(new FieldsCoord("Field 3_", transform).GetCollection());
                extremeBorderPoint1 = new Vector2(5, 7);
                extremeBorderPoint2 = new Vector2(-4,-2f);
                break;

            case 16:
                ListFieldCreator(new FieldsCoord("Field 4_", transform).GetCollection());

                break;

        }
    }

    public static Vector2 GetExtremeBorderPoint1()
    {
        return extremeBorderPoint1;
    }
    public static Vector2 GetExtremeBorderPoint2()
    {
        return extremeBorderPoint2;
    }

    public static List<FieldElement> GetCollection()
    {
        return fields;
    }

    private void ListFieldCreator(List<Vector2> list)
    {
        System.Random rnd = new System.Random();
        var shuffledList = list.OrderBy(item => rnd.Next());
        int index = 1 + rnd.Next(list.Count);
        int inc = 1;
        foreach (Vector2 vect in shuffledList)
        {
            if (inc != index)
            {
                GameObject newObject = (GameObject)Instantiate(prefab);
                elementsArray.Add(newObject);
                newObject.name += Time.deltaTime;
                newObject.transform.parent = this.transform;
                newObject.transform.localPosition = new Vector3(vect.x, vect.y, zValue);
                //Debug.Log(newObject.transform.localPosition);
                newObject.GetComponentInChildren<TextMesh>().text = inc.ToString();
                FieldElement newField = new FieldElement(vect, newObject);
                fields.Add(newField);
                inc++;
            }
            else
            {
                fields.Add(new FieldElement(vect));
                index = -1;
            }
        }
    }


    private class FieldsCoord
    {
        private List<Vector2> fieldsCoord;

        public FieldsCoord(string str, Transform transformComp)
        {
            fieldsCoord = new List<Vector2>();
            foreach (Transform child in transformComp)
            {
                if (child.name.Contains(str) && !child.name.Contains("Clone"))
                {
                    fieldsCoord.Add(new Vector2(child.localPosition.x, child.localPosition.y));
                }
            }
        }
        public List<Vector2> GetCollection() { return fieldsCoord; }
    }
}
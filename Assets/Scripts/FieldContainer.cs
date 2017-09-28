using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldContainer : MonoBehaviour {

    public static List<FieldElement> Fields;

	void Start () {
        if(Fields == null)
        {
            Fields = new List<FieldElement>();

            int size = (int)Preferences.GetFieldSize();

            while(size > Fields.Count)
            {
                Fields.Add(new FieldElement());
            }
        }

    }

}

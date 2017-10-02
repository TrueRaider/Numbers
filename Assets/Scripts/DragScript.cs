using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class DragScript : MonoBehaviour {

    private Vector3 screenPoint;

    private bool yAxisFree = false;

    private bool xAxisFree = false;

    private List<FieldElement> translatedObjects;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        if (MovementHandler.HasXRowFreeField(transform.localPosition.x))
            xAxisFree = true;

        if (MovementHandler.HasYRowFreeField(transform.localPosition.y))
            yAxisFree = true;

        if (xAxisFree || yAxisFree)
            translatedObjects = MovementHandler.GetOsculantObjects(transform.localPosition, xAxisFree, yAxisFree);
    }

    void OnMouseDrag()
    {
        if (xAxisFree || yAxisFree)
        {
            if (xAxisFree)
            {
                Vector3 cursorPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
                if (!MovementHandler.CanBeMoved(cursorPosition))
                    return;
                transform.position = cursorPosition;
                foreach(FieldElement field in translatedObjects)
                {
                    field.fieldObject.transform.position = cursorPosition + (field.fieldObject.transform.position - transform.position);
                }
            }
            if (yAxisFree)
            {
                Vector3 cursorPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
                if (!MovementHandler.CanBeMoved(cursorPosition))
                    return;
                transform.position = cursorPosition;
                foreach (FieldElement field in translatedObjects)
                {
                    field.fieldObject.transform.position = cursorPosition + (field.fieldObject.transform.position - transform.position);
                }
            }
        }
        
    }
    void OnMouseUp()
    {
        if (xAxisFree || yAxisFree)
        {
            yAxisFree = false;
            xAxisFree = false;
            MovementHandler.newHoldPoint(this.gameObject);
            gameObject.transform.DOLocalMove(MovementHandler.GetObjectPosition(this.gameObject), 0.5f);
            if (translatedObjects != null && translatedObjects.Count > 0)
                translatedObjects.Clear();
        }
    }
}

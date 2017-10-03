using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class DragScript : MonoBehaviour {

    private Vector3 screenPoint;

    private bool yAxisFree = false;

    private bool xAxisFree = false;

    private List<FieldElement> translatedObjects;

    private Vector3 PositionChangeVector;

    void OnMouseDown()
    {
        PositionChangeVector = transform.position;
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
            Vector3 tempVector = transform.position;
            if (xAxisFree)
            {
                Vector3 cursorPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
                if (!MovementHandler.CanBeMoved(cursorPosition))
                    return;
                transform.position = cursorPosition;
                if (tempVector != transform.position)
                {
                    foreach (FieldElement field in translatedObjects)
                    {
                        field.fieldObject.transform.position = field.fieldObject.transform.position + (transform.position - tempVector);
                    }
                }
            }
            if (yAxisFree)
            {
                Vector3 cursorPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
                if (!MovementHandler.CanBeMoved(cursorPosition))
                    return;
                transform.position = cursorPosition;
                if (tempVector != transform.position)
                {
                    foreach (FieldElement field in translatedObjects)
                    {
                        field.fieldObject.transform.position = field.fieldObject.transform.position + (transform.position - tempVector);
                    }
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
            if (translatedObjects != null && translatedObjects.Count > 0)
            {
                while(translatedObjects.Count>0)
                {
                    FieldElement tempField = new FieldElement(new Vector2(100,100));
                    foreach (FieldElement field in translatedObjects)
                    {
                        if (Vector2.Distance(field.Coordinate,FieldContainer.GetFreeFieldElement().Coordinate) < Vector2.Distance(tempField.Coordinate, FieldContainer.GetFreeFieldElement().Coordinate))
                        {
                            tempField = field;
                        }
                    }
                    MovementHandler.newHoldPoint(tempField.fieldObject);
                    tempField.fieldObject.transform.DOLocalMove(MovementHandler.GetObjectPosition(tempField.fieldObject), 0.5f);
                    translatedObjects.Remove(tempField);
                }
                translatedObjects.Clear();
            }
            MovementHandler.newHoldPoint(this.gameObject);
            gameObject.transform.DOLocalMove(MovementHandler.GetObjectPosition(this.gameObject), 0.5f);

            ResultHandler.CheckResult();
        }
    }
}

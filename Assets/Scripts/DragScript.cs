using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class DragScript : MonoBehaviour {

    private Vector3 screenPoint;

    private bool yAxisFree = false;

    private bool xAxisFree = false;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        if (MovementHandler.HasXRowFreeField(transform.localPosition.x))
            xAxisFree = true;

        if (MovementHandler.HasYRowFreeField(transform.localPosition.y))
            yAxisFree = true;
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
                List<FieldElement> newContainer = MovementHandler.GetOsculantObjectsX(transform.localPosition);
            }
            if (yAxisFree)
            {
                Vector3 cursorPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
                Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
                if (!MovementHandler.CanBeMoved(cursorPosition))
                    return;
                transform.position = cursorPosition;
                List<FieldElement> newContainer = MovementHandler.GetOsculantObjectsY(transform.localPosition);
            }
        }
        
    }
    void OnMouseUp()
    {
        yAxisFree = false;
        xAxisFree = false;
        //Debug.Log(MovementHandler.GetObjectPosition(this.gameObject));
        gameObject.transform.DOLocalMove(MovementHandler.GetObjectPosition(this.gameObject),0.5f);
        //Debug.Log();
    }
}

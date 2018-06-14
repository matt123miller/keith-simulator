using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    public Vector2 startPos;
    public Vector2 direction;

    public Draggable draggedObject;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // the object identified by hit.transform was clicked
                // do whatever you want
                print(hit.transform);

                if (!draggedObject)
                {
                    draggedObject = hit.transform.GetComponent<Draggable>();

                    if (!draggedObject)
                    {
                        return;
                    }
                    draggedObject.BeginDrag();
                }

                if (draggedObject)
                {
                    draggedObject.DragTo(mousePos);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!draggedObject) return;
            draggedObject.EndDrag();
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}

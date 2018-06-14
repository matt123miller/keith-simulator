using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Draggable : MonoBehaviour {
       
    public Vector3 screenPoint;
    public Vector3 offset;
       
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        BeginDrag();
    }

    void OnMouseDrag()
    {
        MoveFood();
    }

    void OnMouseUp()
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        EndDrag(); 

        // Ray cast, preferably avoiding the layer the food is on.

        // Is it now on the bbq?
    }

    public void BeginDrag()
    {
        print("drag begins");
        offset = gameObject.transform.position - PointerLocation();

    }

    public Vector3 PointerLocation()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    public void MoveFood()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    public void DragTo(Vector2 pos)
    {
        transform.position = pos;
    }

    public void EndDrag()
    {
        print("Drag ended!");
    }
}

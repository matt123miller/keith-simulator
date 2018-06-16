using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Draggable : MonoBehaviour {
       
    public Vector3 screenPoint;
    public Vector3 offset;
    public bool cooking = false;
    
    private Camera camera;
    private Food selfFood;
       
	// Use this for initialization
	void Awake () {
		camera = Camera.main;
        selfFood = transform.GetComponent<Food>();
        print(selfFood);
	}
	
	// Update is called once per frame
	void Update () {
		if(!cooking){
             transform.Translate(Vector3.right * Time.deltaTime);

             if(transform.position.x > 5){
                 Destroy(gameObject);
             }
        }
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
        //raycast down to find the bbq
        int bbqLayerIndex = LayerMask.NameToLayer("BBQ");
        // bit shift dat shit
        int layerMask = (1 << bbqLayerIndex);

        Vector3 down = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        //Raycast with that layer mask
        if (Physics.Raycast(transform.position, down, out hit, Mathf.Infinity, layerMask))
        {
            print(hit.transform);
            BBQ bbq = hit.transform.GetComponent<BBQ>();

            if (!bbq)
            {
                return;
            }
            cooking = true;
            bbq.AcceptFood(selfFood);
        }
    }

    public void BeginDrag()
    {
        print("drag begins");
        offset = gameObject.transform.position - PointerLocation();

    }

    public Vector3 PointerLocation()
    {
        return camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    public void MoveFood()
    {
        transform.position = PointerLocation() + offset;
    }

    public void DragTo(Vector2 pos)
    {
        transform.position = pos;
    }

    public void EndDrag()
    {
        print("Drag ended!");
        // Change some textures and state?
    }
}

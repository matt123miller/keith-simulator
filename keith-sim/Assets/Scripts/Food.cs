using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public Material rawMaterial, cookedMaterial;
    public Renderer renderer;

    public bool flipped = false;
    public float cookPercentage = 0;
    public float cookDuration = 10;
    [Range(0.7f, 1.3f)]
    public float cookRate = 1;

	// Use this for initialization
	void Awake () {
        renderer = transform.GetComponent<Renderer>();
        renderer.material = rawMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cook()
    {
        cookPercentage += (Time.deltaTime * cookRate) / cookDuration;
        // float lerp = Mathf.PingPong(Time.time, cookDuration) / cookDuration;
        if(cookPercentage < 1){
            
            print("Cooking..."+(cookPercentage * 100) + " %");
            renderer.material.Lerp(rawMaterial, cookedMaterial, cookPercentage);
        }
        else { 
            print("Burning!!!!");
        }
    }
}

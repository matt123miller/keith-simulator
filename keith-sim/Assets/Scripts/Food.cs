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
        print("Cooking!");
        float lerp = Mathf.PingPong(Time.time, cookDuration) / cookDuration;
        renderer.material.Lerp(rawMaterial, cookedMaterial, lerp);
    }
}

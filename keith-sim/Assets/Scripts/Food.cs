using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public Color opaqueColour, transparentColour;
    public SpriteRenderer rawRender, cookedRender, burntRender;

    public bool flipped = false;
    public float cookPercentage = 0;
    public float cookDuration = 10;
    [Range(0.7f, 1.3f)]
    public float cookRate = 1;

	// Use this for initialization
	void Awake () {
        rawRender = transform.GetComponent<SpriteRenderer>();
        cookedRender = transform.GetChild(0).GetComponent<SpriteRenderer>();
        burntRender = transform.GetChild(1).GetComponent<SpriteRenderer>();
        
        rawRender.color = opaqueColour;
        cookedRender.color = burntRender.color = transparentColour;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Cook()
    {
        // Lerp anim curves
        // raw to cooked has curve above straight, cooked to burnt has curve below straight.

        cookPercentage += (Time.deltaTime * cookRate) / cookDuration;
        // float lerp = Mathf.PingPong(Time.time, cookDuration) / cookDuration;
        if(cookPercentage < 1){
            
            print("Cooking..."+(cookPercentage * 100) + " %");

            rawRender.color = Color.Lerp(opaqueColour, transparentColour, cookPercentage);
            cookedRender.color = Color.Lerp(transparentColour, opaqueColour, cookPercentage);

            // cookedRender.color = Color.Lerp();
            // spriteRenderer.material.Lerp(rawMaterial, cookedMaterial, cookPercentage);
        }
        else { 
            print("Burning!!!!");
            // Lerp between cooked and burnt!
            cookedRender.color = Color.Lerp(opaqueColour, transparentColour, cookPercentage - 1);
            burntRender.color = Color.Lerp(transparentColour, opaqueColour, cookPercentage - 1);


        }
    }
}

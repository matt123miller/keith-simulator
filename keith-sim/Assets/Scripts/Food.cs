using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public BBQ bbq;
    public Color opaqueColour, transparentColour;
    public SpriteRenderer rawRender, cookedRender, burntRender;

    public float cookPercentage = 0;
    public float cookDuration = 10;
    [Range(0.7f, 1.3f)]
    public float cookRate = 1;

	// Use this for initialization
	void Awake () {
        rawRender = transform.GetComponent<SpriteRenderer>();
        cookedRender = transform.GetChild(0).GetComponent<SpriteRenderer>();
        burntRender = transform.GetChild(1).GetComponent<SpriteRenderer>();
        
        rawRender.color =  cookedRender.color = burntRender.color =opaqueColour;
        // = transparentColour;
	}

	// Tap the food to finish it. Add score depending on cook amount.
	void OnMouseDown()
    {
        if(cookPercentage < 0.1) return;

        // cookPercentage is powered by anim curves so the score can be altered easily.
        int scoreIncrease = (int)(cookPercentage * 100) ;
        Score.Instance.AddScore(scoreIncrease);

        EndCooking();
    }

    public void EndCooking() {
            bbq.ReleaseFood(this);
            Destroy(this.gameObject, 0.01f);
    }

    public void Cook()
    {
        // Lerp anim curves
        // raw to cooked has curve above straight, cooked to burnt has curve below straight.

        cookPercentage += (Time.deltaTime * cookRate) / cookDuration;

        if(cookPercentage < 1){
            
            rawRender.color = Color.Lerp(opaqueColour, transparentColour, cookPercentage);
        }
        else if (cookPercentage < 2) { 
            // Lerp between cooked and burnt!
            cookedRender.color = Color.Lerp(opaqueColour, transparentColour, cookPercentage - 1);
        }
        else {
            EndCooking();
            // Lose score?
            Score.Instance.AddScore(-100);
        }
    }


}

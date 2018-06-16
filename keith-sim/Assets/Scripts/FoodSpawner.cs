using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {

// Spawn food anywhere between the bbq and the bottom of the screen.
// rotate sausages a little

	public Transform bbqRoot;
	public float[] spawnRates;
	public int spawnIndex = 0;
	public float currentSpawnThreshold;
	public float spawnCounter;




	// Use this for initialization
	void Awake () {
		float x = bbqRoot.position.x - (bbqRoot.localScale.x);
		float y = bbqRoot.position.y - (bbqRoot.localScale.y / 2);
		
		// Position is set to the bottom left of the bbq, slightly off screen
		transform.position = new Vector2(x, y);
		// Now you can spawn food off screen anywhere between position.y and 0

		currentSpawnThreshold = spawnRates[spawnIndex];
	}
	
	// Update is called once per frame
	void Update () {
		
		spawnCounter += Time.deltaTime;

		if(spawnCounter > currentSpawnThreshold)
		{
			print("new food! " + currentSpawnThreshold);
			spawnIndex++;
			spawnCounter = 0;
			if(spawnIndex >= spawnRates.Length)
			{
				spawnIndex = 0;
			}
			currentSpawnThreshold = spawnRates[spawnIndex];
		}
	}
}

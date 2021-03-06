﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBQ : MonoBehaviour {

    public List<Food> food = new List<Food>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Food item in food.ToArray())
        {
            item.Cook();
        }
	}

    public void AcceptFood(Food _food)
    {
        food.Add(_food);
        _food.bbq = this;
    }

    public void ReleaseFood(Food _food)
    {
        food.Remove(_food);
    }
}

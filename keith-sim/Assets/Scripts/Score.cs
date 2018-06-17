using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private static Score _instance;
	  // Singleton object, access this via GlobalGameManager.Instance whenever you need the global stuff.
    public static Score Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindWithTag("Score").GetComponent<Score>();
            }
            return _instance;
        }
	}

	public Text text;
	public int score = 0;

	// Use this for initialization
	void Awake () {
		text = transform.GetComponent<Text>();
		AddScore(0);
	}
	
	public void AddScore(int _score) {
		score += _score;
		text.text = "Score: " + score;
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text myText = GetComponent<Text>();
        myText.text = "Score: " + Global.score;
        Global.Reset();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

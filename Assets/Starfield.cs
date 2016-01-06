using UnityEngine;
using System.Collections;

public class Starfield : MonoBehaviour {

    static int starfields = 0;
	// Use this for initialization
	void Start () {
		if (starfields >= 4) {
			Destroy (gameObject);
		} else {
            starfields++;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {

    public static Global instance;
    public static int score;
    public static int money;
    public static float playerHealth;
    public const float PlayerMaxHealth = 1000f;

	void Start () {
        if (instance == null){
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            Reset(); // Initialize values
        }else {
            Destroy(gameObject);
        }
	}

	public static void Reset () {
        score = 0;
        money = 0;
        playerHealth = PlayerMaxHealth;
	}
}

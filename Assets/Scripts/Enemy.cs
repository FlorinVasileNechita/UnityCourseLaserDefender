using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    float health;
    float shotsPerSecond = 0.33f;
    public static int totalEnemies = 0;
    EnemySpawner enemySpawner;
    Text score;


    public void Initialize(float hp){
        health = hp;
    } // public void Initialize(float hp)

    void CheckHealth(){
        if (health <= 0f){
            Destroy(gameObject);
            Global.score += 10;
            score.text = Global.score.ToString();
            ObjectFactory.CreateExplosion(transform.position);
            if (--totalEnemies <= 0) enemySpawner.CreateEnemies();
        }
    } // void CheckHealth()

    void Start(){
        enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
        score = GameObject.Find("Score").GetComponent<Text>();
        totalEnemies++;
    } // void Start()

    void Update(){
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability) {
            FireLaser();
        }
    } // void Update()

    void FireLaser(){
        ObjectFactory.CreateLaser(transform.position, -1);
    } // void FireLaser()

    public void HitByLaser(Laser laser){
        health -= laser.GetDamage();
        CheckHealth();
    } // public void HitByLaser(Laser laser)

}

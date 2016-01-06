using UnityEngine;
using System.Collections;

// Create objects and set their defaults here.
// Unity does not have a traditional constructor when instantiating an object
// This basically means that you can create an object, but cannot give it any parameters.
// Using this type of methodology allows us to adapt to Unity's implementation.
public class ObjectFactory : MonoBehaviour {

    protected static ObjectFactory instance;
    public GameObject enemyPrefab;
    public GameObject laserPrefab;
    public GameObject explosionPrefab;

    //Singleton
	void Start () {
        if (instance == null) instance = this; else Destroy(gameObject);
	}

    public static Laser CreateLaser(Vector3 pos, int direction, float speed = 10f, float damage = 100f){
        Laser laser = (Instantiate(instance.laserPrefab, pos, Quaternion.identity) as GameObject).GetComponent<Laser>();
        laser.Initialize(direction, speed, damage);
        return laser;
    } // public static Laser CreateLaser(int direction, Vector3 pos)

    public static Enemy CreateEnemy(Vector3 pos, float health = 50f){
        Enemy enemy = ((GameObject)Instantiate(instance.enemyPrefab, pos, Quaternion.identity)).GetComponent<Enemy>();
        enemy.Initialize(health);
        return enemy;
    } // public static EnemySpawner CreateEnemy(Vector3 pos)

    public static Explosion CreateExplosion(Vector3 pos, float size = 2f){
        Explosion explosion = ((GameObject)Instantiate(instance.explosionPrefab, pos, Quaternion.identity)).GetComponent<Explosion>();
        explosion.Initialize(size);
        return explosion;
    } // public static Explosion CreateExplosion(Vector3 pos, float size = 1f)

}

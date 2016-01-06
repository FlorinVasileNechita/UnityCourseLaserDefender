using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class Laser : MonoBehaviour {

    float speed;
    int direction;
    float damage;
    public AudioClip laserSound;
    public AudioClip laserSound2;
    public Sprite[] sprites;

    // Psuedo Constructor because unity is weird
    public void Initialize(int dir, float spd, float dmg){
        direction = dir;
        speed = spd;
        damage = dmg;
    }

    public float GetDamage(){
        return damage;
    } // public float GetDamage()

    public int GetDirection(){
        return direction;
    } // public int GetDirection()

	void Start () {
        if (direction == 1){
            AudioSource.PlayClipAtPoint(laserSound, transform.position, 0.15f);
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }else if (direction == -1) {
            AudioSource.PlayClipAtPoint(laserSound2, transform.position, 0.15f);
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        speed *= Screen.height / 600f; // Normalize speed
	}

	void Update () {
        transform.position += new Vector3(0, speed * direction * Time.deltaTime);
	} // void Update ()

    //void OnCollisionEnter2D (Collision2D collision) {
    //    print(collision.gameObject);
    //    bool hittingBarrier = (Regex.IsMatch(collision.gameObject.ToString(), "Barrier"));
    //} // void OnCollisionEnter2D (Collision2D collision)

    void OnTriggerEnter2D (Collider2D collider) {
        bool hitABarrier = (Regex.IsMatch(collider.gameObject.ToString(), @"Barrier"));
        PlayerController player = collider.gameObject.GetComponent<PlayerController>();
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        if (hitABarrier){
            Destroy(gameObject);
        }else if (enemy && direction == 1) {
            enemy.HitByLaser(this);
            Destroy(gameObject);
        }else if (player && direction == -1) {
            player.HitByLaser(this);
            Destroy(gameObject);
        }
    } // void OnCollisionEnter2D (Collision2D collision)
}

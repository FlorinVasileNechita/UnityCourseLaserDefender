using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 6.5f;
    Vector2 nothing = new Vector2 (0, 0);
    Vector3 leftmost;
    Vector3 rightmost;
    const float buffer = 0.1f;
    public GameObject laserPrefab;
    public float firingRate = 0.33f;
    public Image hpBar;
    LevelManager levelManager;

    void Start () {
        leftmost = (Camera.main.ViewportToWorldPoint(new Vector2(0,0)) + new Vector3(this.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 + buffer, 0, 0));
        rightmost = (Camera.main.ViewportToWorldPoint(new Vector2(1,0)) - new Vector3(this.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 + buffer, 0, 0));
        hpBar = GameObject.Find("HealthBar").GetComponent<Image>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    } // void Start ()

	void Update () {
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))){
            this.GetComponent<Rigidbody2D>().velocity = nothing;
        }else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x > leftmost.x){
            this.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x < rightmost.x){
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }else{
            this.GetComponent<Rigidbody2D>().velocity = nothing;
        } // if ((Input.GetKey(KeyCode.RightArrow) ||...

        if(Input.GetKeyDown(KeyCode.Space)){
            InvokeRepeating("Fire", 0.001f, firingRate);
        } // if(Input.GetKeyDown(KeyCode.Space))
        if(Input.GetKeyUp(KeyCode.Space)){
            CancelInvoke("Fire");
        } // if(Input.GetKeyUp(KeyCode.SPace))
        print(levelManager);


	} // void Update ()

    void CheckHealth(){
        if (Global.playerHealth <= 0f){
            Destroy(gameObject);
            ObjectFactory.CreateExplosion(transform.position);
            levelManager.LoadLevel("Lose Screen");
        }
    }

    public void HitByLaser(Laser laser){
        Global.playerHealth -= laser.GetDamage();
        hpBar.fillAmount -= laser.GetDamage() / Global.PlayerMaxHealth;
        CheckHealth();
    }

    void Fire(){
        ObjectFactory.CreateLaser(transform.position, 1);
    } // void Fire()
} // public class PlayerController : MonoBehaviour

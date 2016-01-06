using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 3f;
    Vector3 leftmost;
    Vector3 rightmost;
    int direction;


	void Start () {

        CreateEnemies();
        leftmost  = (Camera.main.ViewportToWorldPoint(new Vector2(0,0)) + new Vector3(width / 2, 0, 0));
        rightmost = (Camera.main.ViewportToWorldPoint(new Vector2(1,0)) - new Vector3(width / 2, 0, 0));
        direction = Random.Range(0, 2) == 1 ? 1 : -1;
        speed *= Screen.width / 900f; // Normalize speed

	} // void Start ()

    public void CreateEnemies(){
        Transform freePosition = NextFreePosition();
        if (freePosition){
            Enemy enemy = ObjectFactory.CreateEnemy(freePosition.position, 150f);
            enemy.transform.parent = freePosition; // This makes enemies spawn under the Position GameObject in the hierarchy.
        }
        if (NextFreePosition()){
            Invoke ("CreateEnemies", Random.Range(0.5f, 1.0f));
        }
    } // public void CreateEnemies()

    public Transform NextFreePosition(){
        foreach(Transform childPositionTransform in transform){
            if (childPositionTransform.childCount == 0){
                return childPositionTransform;
            }
        }
        return null;
    } // public Transform NextFreePosition()

    public void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    } // public void OnDrawGizmos()

	void Update () {
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0);
        if (transform.position.x >= rightmost.x){
            direction = -1;
        }else if (transform.position.x <= leftmost.x){
            direction = 1;
        } // if (transform.position.x >= rightmost.x)

	} // void Update () 

} // public class EnemySpawner : MonoBehaviour 

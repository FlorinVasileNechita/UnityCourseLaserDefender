using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public AudioClip explosionSound;

    public void Initialize(float size){
        transform.localScale = new Vector3(size,size,0);
    } // public void Initialize(float size){

    public void Start(){
        AudioSource.PlayClipAtPoint(explosionSound, transform.position, 0.15f);
    } // public void Start()

    public void Destroy(){
        Destroy(gameObject);
    } // public void Destroy()
}

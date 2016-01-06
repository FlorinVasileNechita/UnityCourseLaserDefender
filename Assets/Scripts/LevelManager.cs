using UnityEngine;
using System.Collections;
using UnityEditor;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name){
        Debug.Log("Level Load requested for: " + name);
        Application.LoadLevel(name);
    } // public void LoadLevel(string name)

    public void QuitRequest(){
        Debug.Log("Quit Game requested");
        Application.Quit();
    } // public void QuitRequest()

    //public void LoadNextLevel() {
    //    Brick.totalBricks = 0;
    //    if (Application.loadedLevelName == "AutoplayDemo") Application.LoadLevel(0);
    //    else Application.LoadLevel(Application.loadedLevel + 1);
    //} // public void LoadNextLevel() 

    //public void BrickDestroyed() {
    //    if (Brick.totalBricks <= 0) {
    //        LoadNextLevel();
    //    } // if (Brick.totalBricks <= 0)
    //} // public void BrickDestroyed()

    //public void Update(){
    //    print(EditorApplication.currentScene);
    //} //public void Update()

} // public class LevelManager : MonoBehaviour 

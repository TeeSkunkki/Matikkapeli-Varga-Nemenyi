using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakaisinMainMenu : MonoBehaviour
{
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(SceneManager.GetActiveScene().name == SceneManager.GetSceneAt(0).name){
                SceneManager.LoadScene(0);
            }else{
                Application.Quit();
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private GameObject[] Grid;


    // Start is called before the first frame update
    void Start(){
        Grid = new GameObject[GameObject.Find("BGRect").transform.childCount - 1];
        for(int i = 0; i < Grid.Length; i++){
            Grid[i] = GameObject.FindGameObjectsWithTag("Pala")[i];
            
        }
    }

    // Update is called once per frame
    void Update(){
        
    }
}

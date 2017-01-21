using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManatee : MonoBehaviour {
    bool mouseInsideButton = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)&& mouseInsideButton)
        {
           SceneManager.LoadScene("Scene1");
        }
        
	}
    void OnMouseEnter()
    {
        print("enter");
        mouseInsideButton = true;
    }
    void OnMouseExit ()
    {
        mouseInsideButton = false;
    }
}

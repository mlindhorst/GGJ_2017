using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name == "Scene1")
            {
                SceneManager.LoadScene("Menu");
                return;
            }
            Application.Quit();
        }
	}
}

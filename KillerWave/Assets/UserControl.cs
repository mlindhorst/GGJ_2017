using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour {

    public float PowerBarAmmount = 20;
    public float movementSpeed;
    private DropPowerManager _dropPowerManager;
    public static UserControl instance;
    public Action UpdateBar;
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        UpdateBar = delegate { };
        _dropPowerManager = GetComponent<DropPowerManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
		if( Input.GetKey( KeyCode.UpArrow ) && transform.position.y < -90 && PowerBarAmmount > 0)
        {
            UpdateBar();
            PowerBarAmmount = PowerBarAmmount - .5f; ;
            transform.position = 
                new Vector3(transform.position.x, transform.position.y + movementSpeed, transform.position.z);
        }
        else if( Input.GetKey( KeyCode.Space) && transform.position.y > -230)
        {
            transform.position =
                new Vector3(transform.position.x, transform.position.y - 30, transform.position.z);
            _dropPowerManager.UsePowerUp();
        }
        if (PowerBarAmmount < 20 && !Input.GetKey(KeyCode.UpArrow))
        {
            UpdateBar();
            PowerBarAmmount += .2f;
        }
    }
}

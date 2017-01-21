using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileImage : MonoBehaviour {
    public float scrollSpeed;
    public int width;
    public int height;

    private Vector3 backPos;
    private float X;
    private float Y;


    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = transform.position + Vector3.left * scrollSpeed;
    }

    void OnBecameInvisible()
    {
        //calculate current position
        backPos = gameObject.transform.position;
        //calculate new position
        print(backPos);
        X = backPos.x + width * 2;
        Y = backPos.y + height * 2;
        //move to new position when invisible
        gameObject.transform.position = new Vector3(X, Y, gameObject.transform.position.z);
    }
}

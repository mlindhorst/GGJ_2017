using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour {
    public Text distanceText;

    private int totalDistance;
    private bool readyToMove;

    // Use this for initialization
    void Start () {
        totalDistance = 0;
        distanceText.text = CurrentDistanceText;
        readyToMove = true;
    }
	
    IEnumerator WaitForDistance()
    {
        readyToMove = false;
        yield return new WaitForSeconds(.2f);
        distanceText.text = CurrentDistanceText;
        readyToMove = true;
    }

	// Update is called once per frame
	void Update () {
        if (readyToMove)
        {
            StartCoroutine(WaitForDistance());
        }
    }

    string CurrentDistanceText
    {
        get { return "Distance: " + totalDistance++; }
    }
}

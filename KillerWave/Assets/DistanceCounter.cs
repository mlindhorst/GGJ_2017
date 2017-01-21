using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour {
    public Text distanceText;

    public static DistanceCounter instance;
    private static float totalDistance;
    private static int totalDistanceInt;
    private bool readyToMove;
    
    // Use this for initialization
    void Start () {
        instance = this;
        totalDistance = 0;
        distanceText.text = CurrentDistanceText;
        readyToMove = true;
    }
    void FixedUpdate()
    {
        IncrementDistance(ObstacleMovement.instance.scrollSpeed);
    }
    public void IncrementDistance(int speed)
    {
        totalDistance += speed;
        totalDistanceInt = (int) totalDistance / 10;
        distanceText.text = CurrentDistanceText;
    }


    string CurrentDistanceText
    {
        get { return "Distance: " + totalDistanceInt; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour {
    public Text distanceText;

    public static DistanceCounter instance;
    private static float totalDistance;
    private static int totalDistanceInt;
    private bool readyToMove;
    public float obstacleSendSpeed = 1.5f;
    
    // Use this for initialization
    void Start () {
        instance = this;
        totalDistance = 0;
        distanceText.text = CurrentDistanceText;
        readyToMove = true;
    }
    void SlowlySpeedUp()
    {
       foreach(var obstacleSprite in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            var previousSpeed = obstacleSprite.GetComponent<ObstacleMovement>().scrollSpeed;
            var newSpeed = previousSpeed + .0005f;
            obstacleSendSpeed = newSpeed;
            obstacleSprite.GetComponent<ObstacleMovement>().scrollSpeed = newSpeed;
        }
       foreach(var waterSprite in GameObject.FindGameObjectsWithTag("Water").ToList())
        {
            var previousSpeed = waterSprite.GetComponent<TileImage>().scrollSpeed;
            var newSpeed = previousSpeed + .0005f;
            waterSprite.GetComponent<TileImage>().scrollSpeed = newSpeed;
        }
    }
    void FixedUpdate()
    {
        IncrementDistance(ObstacleMovement.instance.scrollSpeed);
        SlowlySpeedUp();
    }
    public void IncrementDistance(float speed)
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

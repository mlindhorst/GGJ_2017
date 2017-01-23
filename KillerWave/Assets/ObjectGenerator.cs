using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {
    public List<GameObject> GroundObstacles;
    public List<GameObject> SkyObstacles;
    public List<GameObject> Clouds;
    public List<GameObject> Islands;
    public List<GameObject> PowerUps;

    private bool readyForObstacle = true;
    private bool readyForClouds = true;
    private bool readyForIslands = true;
    private static float SKY_MAX_Y = 147;
    private static float SKY_MIN_Y = 15;
    private static float GROUND_MAX_Y = -120;
    private static float GROUND_MIN_Y = -210;
    private int _currentClouds = 0;
    private int _currentIslands = 0;

    // Use this for initialization
    void Start () {
	}


	IEnumerator WaitForObstacle(float timeOutSec, GameObject objectToSummon,float floor, float ceiling)
    {        
        readyForObstacle = false;
        yield return new WaitForSeconds(timeOutSec);
        
        GameObject newObstacle = Instantiate(objectToSummon, new Vector2(750, Random.Range(floor, ceiling)), new Quaternion());
        newObstacle.AddComponent<ObstacleMovement>();
        var renderer = newObstacle.GetComponent<SpriteRenderer>();
        newObstacle.tag = "Obstacle";
        renderer.sortingOrder = 2;

        readyForObstacle = true;
    }
    IEnumerator CalculateAndSendClouds()
    {
        readyForClouds = false;
        _currentClouds = GameObject.FindGameObjectsWithTag("Cloud").ToList().Count;
        yield return new WaitForSeconds(30);
        if(_currentClouds < 3)
        {
            var randomIndex = Random.Range(0, Clouds.Count);
            var objectToSummon = Clouds[randomIndex];
            GameObject newObstacle = Instantiate(objectToSummon, new Vector2(-480, Random.Range(SKY_MIN_Y, SKY_MAX_Y)), new Quaternion());
            newObstacle.AddComponent<ObstacleMovement>();
            var renderer = newObstacle.GetComponent<SpriteRenderer>();
            renderer.sortingOrder = 1;
            readyForClouds = true;
        }
    }
    IEnumerator CalculateAndSendIslands()
    {
        readyForIslands = false;
        _currentIslands = GameObject.FindGameObjectsWithTag("Island").ToList().Count;
        yield return new WaitForSeconds(15);
        if (_currentIslands < 3)
        {
            var randomIndex = Random.Range(0, Islands.Count);
            var objectToSummon = Islands[randomIndex];
            GameObject newObstacle = Instantiate(objectToSummon, new Vector2(750, Random.Range(GROUND_MIN_Y+40, GROUND_MAX_Y+20)), new Quaternion());
            newObstacle.AddComponent<ObstacleMovement>();
            var renderer = newObstacle.GetComponent<SpriteRenderer>();
            renderer.sortingOrder = 0;
            readyForIslands = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (readyForClouds)
        {
            StartCoroutine(CalculateAndSendClouds());
        }
        if (readyForIslands)
        {
            StartCoroutine(CalculateAndSendIslands());
        }
        if (readyForObstacle)
        {
            var objectTypeDetermine = Random.Range(0, 2);
            GameObject objectToSummon = null;
            float floor = 0;
            float ceiling = 0;
            if (objectTypeDetermine < 1)
            {
                var randomIndex = Random.Range(0, SkyObstacles.Count);
                objectToSummon = SkyObstacles[randomIndex];
                floor = SKY_MIN_Y;
                ceiling = SKY_MAX_Y;
            }
            else
            {
                var generatePowerUp = Random.Range(0, 4);
                if (generatePowerUp < 1)
                {
                    var powerUpRandomIndex = Random.Range(0, PowerUps.Count);
                    objectToSummon = PowerUps[powerUpRandomIndex];
                    floor = SKY_MIN_Y;
                    ceiling = -130;
                }
                else
                {
                    var randomIndex = Random.Range(0, GroundObstacles.Count);
                    objectToSummon = GroundObstacles[randomIndex];
                    floor = GROUND_MIN_Y;
                    ceiling = GROUND_MAX_Y;
                }
            }
            StartCoroutine(WaitForObstacle(Random.Range(1, 3), objectToSummon, floor, ceiling));
        }
	}
}

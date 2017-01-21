using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {
    public List<GameObject> GroundObstacles;
    public List<GameObject> SkyObstacles;
    public List<GameObject> Clouds;

    private bool readyForObstacle = true;
    private bool readyForClouds = true;
    private static float SKY_MAX_Y = 147;
    private static float SKY_MIN_Y = 15;
    private static float GROUND_MAX_Y = -90;
    private static float GROUND_MIN_Y = -180;
    private int _currentClouds = 0;

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
	// Update is called once per frame
	void Update()
    {
        if (readyForClouds)
        {
            StartCoroutine(CalculateAndSendClouds());
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
                var randomIndex = Random.Range(0, GroundObstacles.Count);
                objectToSummon = GroundObstacles[randomIndex];
                floor = GROUND_MIN_Y;
                ceiling = GROUND_MAX_Y;
            }


            StartCoroutine(WaitForObstacle(Random.Range(2, 5), objectToSummon, floor, ceiling));
        }
	}
}

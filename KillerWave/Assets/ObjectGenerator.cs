using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {
    public List<GameObject> GroundObstacles;
    public List<GameObject> SkyObstacles;

    private bool readyForObstacle = true;
    private static float SKY_MAX_Y = 147;
    private static float SKY_MIN_Y = 15;
    private static float GROUND_MAX_Y = 0;
    private static float GROUND_MIN_Y = -149;

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
        renderer.sortingOrder = 1;

        readyForObstacle = true;
    }

	// Update is called once per frame
	void Update()
    {
        if (readyForObstacle)
        {
            var objectTypeDetermine = Random.Range(0, 4);
            GameObject objectToSummon = null;
            float floor = 0;
            float ceiling = 0;
            if (objectTypeDetermine < 1)
            {
                var randomIndex = Random.Range(0, SkyObstacles.Count - 1);
                objectToSummon = SkyObstacles[randomIndex];
                floor = SKY_MIN_Y;
                ceiling = SKY_MAX_Y;
            }
            else
            {
                var randomIndex = Random.Range(0, GroundObstacles.Count - 1);
                objectToSummon = GroundObstacles[randomIndex];
                floor = GROUND_MIN_Y;
                ceiling = GROUND_MAX_Y;
            }


            StartCoroutine(WaitForObstacle(Random.Range(.5f, 5), objectToSummon, floor, ceiling));
        }
	}
}

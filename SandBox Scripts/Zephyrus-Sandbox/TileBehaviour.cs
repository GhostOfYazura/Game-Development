using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    private float AliveTime;
      
    void Update()
    {
        gameObject.transform.position = new Vector3(0, 0, gameObject.transform.position.z - DistanceToTravelFormula());
        AliveTime += Time.deltaTime;
        if (AliveTime >= 30f)
        {
            Destroy(gameObject);
        }
    }


    // We want to travel 15 units every 5 seconds this forumla does this based on time not frame-rate.
    float DistanceToTravelFormula()
    {
        float Dis = 3f;
        float time_in_seconds = Time.deltaTime;
        return Dis * time_in_seconds;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject path;
    public float PathGenTimer = 0;

    void Update()
    {
        PathGenTimer += Time.deltaTime;
        if (PathGenTimer >= 5f)
        {
            Instantiate(path, new Vector3(0f, 0f, 30f), Quaternion.identity);
            PathGenTimer = 0;
        }
    }
}

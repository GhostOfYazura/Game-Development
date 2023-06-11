using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paranormal_Activities : MonoBehaviour
{
    [SerializeField]
    public bool Disco = false;

    [SerializeField]
    GameObject DL;
    private float AnomalyTimer;

    //Private variables for anomalies.
    private Color DiscoDirectionalLightLerp;
    private Color DL_DefaultColor;
    private float DDLL_AnomalyTimer;

    void Start()
    {
        DL_DefaultColor = DL.GetComponent<Light>().color;
    }
    void Update()
    {
        AnomalyTimer += Time.deltaTime;
        DDLL_AnomalyTimer += Time.deltaTime;
        AnomalyActiveChecker();
        if (AnomalyTimer > 5)
        {
            if (Random.Range(0,100) > 10)
            {
                RandomAnomalySelector();
            }
            AnomalyTimer = 0;
        }
    }

    void AnomalyActiveChecker()
    {
        if (Disco)
        {
            DiscoDirectionalLight();
        }
    }

    void RandomAnomalySelector()
    {
        //Code goes here
        int ActiveThisAnomaly = Random.Range(1,2);
        switch (ActiveThisAnomaly){
            case 1:
                Disco = true;
                break;
            default:
                break;
        }
    }

    // All of the anomaly functions past this point.
    void DiscoDirectionalLight()
    {
        if (DDLL_AnomalyTimer >= 3)
        {
            DDLL_AnomalyTimer = 0;
            DL.GetComponent<Light>().color = Color.Lerp(DL.GetComponent<Light>().color, DiscoDirectionalLightLerp, (1));
        }
        else
        {
            DL.GetComponent<Light>().color = Color.Lerp(DL.GetComponent<Light>().color, DiscoDirectionalLightLerp, (Time.deltaTime));
        }
        if (DiscoDirectionalLightLerp == DL.GetComponent<Light>().color)
        {
            DiscoDirectionalLightLerp = new Color(Random.Range(0f,1f), Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f));
        }
    }
    void DiscoDirectionalLightFix()
    {
        Disco = false;
        DL.GetComponent<Light>().color = DL_DefaultColor;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    //UI Timer Variables
    [SerializeField]
    Text ClockTimeText;
    private int ClockTimeHour = 22;
    private int ClockTimeMinute;
    private float ClockTimeSecond;

    // Start is called before the first frame update
    void Start()
    {
        UpdateClockText();
    }

    // Update is called once per frame
    void Update()
    {
        TimerUpdate();
    }



    // Updates the time value behind the scenes.
    void TimerUpdate()
    {
        ClockTimeSecond += Time.deltaTime;
        if (ClockTimeSecond > 1)
        {
            ClockTimeMinute++;
            ClockTimeSecond = 0;
            if (ClockTimeMinute > 60)
            {
                ClockTimeHour++;
                ClockTimeMinute = 0;
                if (ClockTimeHour >= 24)
                {
                    ClockTimeHour = 0;
                }
            }
            UpdateClockText();
        }
    }

    public void UndoTheWeirdThing()
    {
        /*ExampleScript is written here
        This example is removing the RGB Disco direction light anomaly.
        For that we need to have a way of that happening as well.
        */
        gameObject.SendMessage("DiscoDirectionalLightFix");
    }

    //Updates the user facing value to reflect the behind the scenes time.
    void UpdateClockText()
    {

        if (ClockTimeHour < 10)
        {     
            if (ClockTimeMinute < 10)
            {
                ClockTimeText.text = "0" + ClockTimeHour.ToString() + ":0" + ClockTimeMinute;    
            }
            else
            {
                ClockTimeText.text = "0" + ClockTimeHour.ToString() + ':' + ClockTimeMinute;
            }
        }
        else
        {
            if (ClockTimeMinute < 10)
            {
                ClockTimeText.text = ClockTimeHour.ToString() + ":0" + ClockTimeMinute;    
            }
            else
            {
                ClockTimeText.text = ClockTimeHour.ToString() + ':' + ClockTimeMinute;
            }
        }
    }
}

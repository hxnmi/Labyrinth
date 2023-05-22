using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrientationTest : MonoBehaviour
{
    [SerializeField] TMP_Text systemInfoText;
    // Start is called before the first frame update
    void Start()
    {
        systemInfoText.text = "Sensors :";
        if (SystemInfo.supportsAccelerometer)
            systemInfoText.text = " Accelerometer";

        if (SystemInfo.supportsGyroscope)
        {
            systemInfoText.text = " Gyroscope";
            Input.gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // switch(mode)
        // {
        //     case Mode.gravity:
        //         this.transform.up = -Input.gyro.gravity;
        //         break;
        //     case Mode.acceleration:
        //         this.transform.up = -Input.acceleration;
        //         break;
        // }
    }
}
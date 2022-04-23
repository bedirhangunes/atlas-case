using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public float second = 60;
    public bool timeRun = false;
    public Text texTime;
    void Start()
    {
        timeRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRun)
        {
            if (second > 0)
            {
                second -= Time.deltaTime;
                displayTime(second);
            }
            else
            {
                second = 0;
                timeRun = false;
                SceneManager.LoadScene("level1");
            }
        }
    }
    void displayTime(float timeTo)
    {
        timeTo += 1;
        float seconds = Mathf.FloorToInt(timeTo % 60);
        texTime.text = "Second: " + seconds;
    }
}

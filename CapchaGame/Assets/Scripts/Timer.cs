using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float MaxTime;
    private Image TimeBar;
    private float Timeleft;
    

    void Start()
    {
        Timeleft = MaxTime;
        TimeBar = GetComponent<Image>();
        
    }


    void Update()
    {
        TimerStuff();

    }

    public void TimerStuff()
    {

        if (Timeleft >= 0)
        {
            Timeleft -= Time.deltaTime;
            TimeBar.fillAmount = Timeleft / MaxTime;
        }
        else
        {

        }
        
            
    }
}

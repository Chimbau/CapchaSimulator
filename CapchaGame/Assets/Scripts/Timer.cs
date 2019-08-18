using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float BaseMaxTime;
    public float timePerImage;
    private Image TimeBar;
    public float Timeleft;

    public GameManager gameManager;
    public PlayerHealth health;

    

    void Start()
    {
        //Timeleft = BaseMaxTime;
        TimeBar = GetComponent<Image>();
        
    }


    void Update()
    {

        /*if(gameManager.currentImagemIndex != -1 && !started)
        {
            Timeleft = gameManager.GetMaxTime();
            started = true;
        }*/

        TimerStuff();

    }

    public void TimerStuff()
    {

        if (Timeleft >= 0)
        {
            if (!gameManager.hasScoreTimeStarted)
            {
                Timeleft -= Time.deltaTime;
                TimeBar.fillAmount = Timeleft / gameManager.GetMaxTime();
            }
           
        }
        else
        {
            health.LoseHealth();
            gameManager.ButtonNextClicked();
            Timeleft = gameManager.GetMaxTime();
        }
        
            
    }

    
}

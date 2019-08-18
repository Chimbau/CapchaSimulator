using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int Health;
    public GameObject[] HealthPanels;

   
    public void LoseHealth()
    {
        if (Health >= 1)
        {
            Health--;
        }
        HealthPanels[Health].SetActive(false);
        
    }
    
}

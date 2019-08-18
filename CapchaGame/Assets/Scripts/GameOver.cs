using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public static int win = 0;
    public static int points = 0;
    public GameObject VictoryO;
    public GameObject DefeatO;
    public Text pointsText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame(int totalpoints){
      win = 1;
      points = totalpoints;
      SceneManager.LoadScene(2);
    }

    public void Defeat(){
      win = 0;
      SceneManager.LoadScene(2);
    }

    public void GetScore(){
      if(win == 0){
        DefeatO.SetActive(true);
      }
      else
        VictoryO.SetActive(true);

      pointsText.text = points.ToString();
    }

}

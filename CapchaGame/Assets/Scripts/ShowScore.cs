using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.GetComponent<GameOver>().GetScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

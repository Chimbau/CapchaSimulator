using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ImagesScript : MonoBehaviour
{

    public List<Sprite> ImageList;
    public bool[] RighImageSequence = new bool[9];
    public int corretImageNumber = 0;

    void Awake()
    {
        calculateCorretImageNumber();
    }


    public void calculateCorretImageNumber()
    {
        for (int i = 0; i <RighImageSequence.Length; i++)
        {
            if (RighImageSequence[i])
            {
                corretImageNumber++;
            }
            
        }
    }


   
}

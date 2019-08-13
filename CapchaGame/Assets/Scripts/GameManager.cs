using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public List<ImagesScript> imageList;
    public List<GameObject> ButtonList;
    public int currentImagemIndex = 0;

    public bool[] selectedImages = new bool[9];

    public TextMeshProUGUI hintText;


    void Start()
    {
        for (int i = 0; i <selectedImages.Length; i++)
        {
            selectedImages[i] = false;
        }
        hintText.text = imageList[currentImagemIndex].GetComponent<Text>().text;
    }


    public void ButtonNextClicked()
    {

        if (currentImagemIndex < imageList.Count)
        {
            bool CheckSequence = true;
            for (int i = 0; i < selectedImages.Length; i++)
            {
                if (selectedImages[i] != imageList[currentImagemIndex].RighImageSequence[i])
                {
                    CheckSequence = false;
                    break;
                }
            }

            if (CheckSequence)
            {
                NextImage();
                CheckSequence = false;
            }
            else
            {
                ResetSelectedImages();
                CheckSequence = false;
            }
        }
       
    }


    public void NextImage()
    {
      
        ResetSelectedImages();   
        currentImagemIndex++;
       
        if (currentImagemIndex < imageList.Count)
        {
            hintText.text = imageList[currentImagemIndex].GetComponent<Text>().text;
            for (int i = 0; i < 9; i++)
            {
                ButtonList[i].GetComponent<Image>().sprite = imageList[currentImagemIndex].ImageList[i];

            }
        }
        
    }


    public void ResetSelectedImages()
    {
        for(int i = 0; i < selectedImages.Length; i++)
        {
            selectedImages[i] = false;
            changeButtonColor(i);

        }
    }






    public void Button1Clicked()
    {
        int buttonIndex = 0;
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
       
        
    }
    public void Button2Clicked()
    {

        int buttonIndex = 1;
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
    }

    public void Button3Clicked()
    {
        int buttonIndex = 2;
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
    }

    public void Button4Clicked()
    {
        int buttonIndex = 3;
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
    }

    public void Button5Clicked()
    {
        int buttonIndex = 4;
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
    }

    public void Button6Clicked()
    {
        int buttonIndex = 5;
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
    }

    public void Button7Clicked()
    {
        int buttonIndex = 6;
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
    }

    public void Button8Clicked()
    {
        int buttonIndex = 7;
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
    }

    public void Button9Clicked()
    {
        int buttonIndex = 8;
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
    }


    public void changeButtonColor(int aux)
    {
        if (selectedImages[aux])
        {
            ButtonList[aux].GetComponent<Image>().color = Color.gray;
        }
        else
        {
            ButtonList[aux].GetComponent<Image>().color = Color.white;
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{
    public List<ImagesScript> imageList;
    public List<GameObject> ButtonList9;
    public List<GameObject> ButtonList16;

    public GameObject Panel9;
    public GameObject Panel16;
    
    public int currentImagemIndex = -1;

    public bool[] selectedImages = new bool[16];

    public TextMeshProUGUI hintText;


    void Start()
    {
        for (int i = 0; i < selectedImages.Length; i++)
        {
            selectedImages[i] = false;
        }
        NextImage();
        //hintText.text = imageList[currentImagemIndex].GetComponent<Text>().text;

    }


    public void ButtonNextClicked()
    {

        if (currentImagemIndex < imageList.Count)
        {
            bool CheckSequence = true;
            for (int i = 0; i < imageList[currentImagemIndex].RighImageSequence.Length; i++)
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
            if (imageList[currentImagemIndex].ImageList.Count == 9)
            {
                Panel16.SetActive(false);
                Panel9.SetActive(true);
                for (int i = 0; i < 9; i++)
                {
                    ButtonList9[i].GetComponent<Image>().sprite = imageList[currentImagemIndex].ImageList[i];

                }
            }
            else if (imageList[currentImagemIndex].ImageList.Count == 16)
            {
                Panel9.SetActive(false);
                Panel16.SetActive(true);
                
                for (int i = 0; i < 16; i++)
                {
                    ButtonList16[i].GetComponent<Image>().sprite = imageList[currentImagemIndex].ImageList[i];

                }
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


    public void ImageButtonClicked()
    {
        int buttonIndex = 0;
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "Button":
                buttonIndex = 0;           
                break;
            case "Button (1)":
                buttonIndex = 1;
                break;
            case "Button (2)":
                buttonIndex = 2;
                break;
            case "Button (3)":
                buttonIndex = 3;
                break;
            case "Button (4)":
                buttonIndex = 4;
                break;
            case "Button (5)":
                buttonIndex = 5;
                break;
            case "Button (6)":
                buttonIndex = 6;
                break;
            case "Button (7)":
                buttonIndex = 7;
                break;
            case "Button (8)":
                buttonIndex = 8;
                break;
            case "Button (9)":
                buttonIndex = 9;
                break;
            case "Button (10)":
                buttonIndex = 10;
                break;
            case "Button (11)":
                buttonIndex = 11;
                break;
            case "Button (12)":
                buttonIndex = 12;
                break;
            case "Button (13)":
                buttonIndex = 13;
                break;
            case "Button (14)":
                buttonIndex = 14;
                break;
            case "Button (15)":
                buttonIndex = 15;
                break;
        }
        selectedImages[buttonIndex] = !selectedImages[buttonIndex];
        changeButtonColor(buttonIndex);
    }


    /*
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

    */


    public void changeButtonColor(int aux)
    {

        if (Panel9.activeSelf)
        {
            if (aux < ButtonList9.Count)
            {
                if (selectedImages[aux])
                {
                    ButtonList9[aux].GetComponent<Image>().color = Color.gray;
                }
                else
                {
                    ButtonList9[aux].GetComponent<Image>().color = Color.white;
                }
            }
        }
        else if (Panel16.activeSelf)
        {
            if (selectedImages[aux])
            {
                ButtonList16[aux].GetComponent<Image>().color = Color.gray;
            }
            else
            {
                ButtonList16[aux].GetComponent<Image>().color = Color.white;
            }
        }

       
      
    }
    



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public List<ImagesScript> imageList;
    public List<ImagesScript> imageListBackup;
    public List<GameObject> ButtonList9;
    public List<GameObject> ButtonList16;

    public GameObject Panel9;
    public GameObject Panel16;

    public GameObject GameOver;

    public int currentImagemIndex = -1;

    public bool[] selectedImages = new bool[16];

    public TextMeshProUGUI hintText;
    public TextMeshProUGUI scoreText;

    public Timer timer;
    private float maxTime;

    public float pefectMultiplierValue;

    private static int score = 0;
    private float addScore = 0f;
    private float perfectMultuplier;
    private int RightImageCout = 0;
    private int WrongImageCout = 0;
    private int RawScore;
    private int TimerMultiplier;
    private int TotalScore;

    public float TimeBetweenImages = 3f;
    private float timeScoreLeft;
    public bool hasScoreTimeStarted = false;
    public GameObject ScoreOfImage;

    public TextMeshProUGUI RightImages;
    public TextMeshProUGUI WrongImages;
    public TextMeshProUGUI RawScoreText;
    public TextMeshProUGUI TimeLeftMultiplier;
    public TextMeshProUGUI PerfectRoundMulti;
    public TextMeshProUGUI TotalRoundScore;




    void Update()
    {
        if (hasScoreTimeStarted)
        {
            StartScoreTime();
        }
        //Debug.Log(CalculateTimerMultiplier());

    }

    void Start()
    {
        timeScoreLeft = TimeBetweenImages;
        imageListBackup = imageList;


        for (int i = 0; i < selectedImages.Length; i++)
        {
            selectedImages[i] = false;
        }
        NextImage();
        //hintText.text = imageList[currentImagemIndex].GetComponent<Text>().text;

    }


    public void ButtonNextClicked()
    {
        if (!hasScoreTimeStarted)
        {
            addScore = 0f;
            RightImageCout = 0;
            WrongImageCout = 0;
            perfectMultuplier = pefectMultiplierValue;

            if (currentImagemIndex < imageList.Count)
            {
                for (int i = 0; i < imageList[currentImagemIndex].RighImageSequence.Length; i++)
                {
                    if (selectedImages[i] == true && selectedImages[i] == imageList[currentImagemIndex].RighImageSequence[i])
                    {
                        addScore += 100f / imageList[currentImagemIndex].corretImageNumber;
                        RightImageCout++;
                    }
                    else if (selectedImages[i] == true && selectedImages[i] != imageList[currentImagemIndex].RighImageSequence[i])
                    {
                        WrongImageCout++;
                        addScore -= 100f / imageList[currentImagemIndex].corretImageNumber;
                    }

                    if (selectedImages[i] != imageList[currentImagemIndex].RighImageSequence[i])
                    {
                        perfectMultuplier = 1f;
                    }
                }



                if (addScore > 99f)
                {
                    addScore = 100f;
                }
                else if (addScore <= 0f)
                {
                    addScore = 0f;
                }

                RawScore = (int)addScore;


                TimerMultiplier = CalculateTimerMultiplier();
                if (TimerMultiplier < 1)
                {
                    TimerMultiplier = 1;
                }

                addScore = (int)addScore * TimerMultiplier * perfectMultuplier;
                TotalScore = (int)addScore;
                //SetScore();



                score += (int)addScore;
                UpdateScore();
                hasScoreTimeStarted = true;
                StartCoroutine(SetScore());

            }
        }
    }


    public void NextImage()
    {

        ResetSelectedImages();
        ResetScoreImage();


        int imageCount = imageList.Count;

        currentImagemIndex = Random.Range(0, imageCount);



        //currentImagemIndex++;

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

            SetMaxTime(currentImagemIndex);

            timer.Timeleft = maxTime;




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


    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }


    public void SetMaxTime(int imageIndex)
    {
       // Debug.Log(imageList[imageIndex].corretImageNumber);
       maxTime =  timer.BaseMaxTime + timer.timePerImage * imageList[imageIndex].corretImageNumber;

    }

    public float GetMaxTime()
    {
        return maxTime;
    }

    public int CalculateTimerMultiplier()
    {
        return  (int) ((timer.Timeleft / maxTime) *  10);
    }


    public void StartScoreTime()
    {
        ScoreOfImage.SetActive(true);
        if (timeScoreLeft >= 0)
        {
            timeScoreLeft -= Time.deltaTime;
        }
        else
        {
            ScoreOfImage.SetActive(false);
            hasScoreTimeStarted = false;
            timeScoreLeft = TimeBetweenImages;
            imageList.RemoveAt(currentImagemIndex);
            if(imageList.Count == 0)
              GameOver.GetComponent<GameOver>().EndGame(score);
            NextImage();
        }

    }

    IEnumerator SetScore()
    {
        yield return new WaitForSeconds(0.5f);
        RightImages.SetText(RightImageCout.ToString() + "/" + imageList[currentImagemIndex].corretImageNumber);
        yield return new WaitForSeconds(0.5f);
        WrongImages.SetText(WrongImageCout.ToString());
        yield return new WaitForSeconds(0.5f);
        RawScoreText.SetText(RawScore.ToString());
        yield return new WaitForSeconds(0.5f);
        TimeLeftMultiplier.SetText("x" + TimerMultiplier.ToString());
        yield return new WaitForSeconds(0.5f);
        PerfectRoundMulti.SetText("x" + perfectMultuplier.ToString());
        yield return new WaitForSeconds(0.5f);
        TotalRoundScore.SetText(TotalScore.ToString());

    }

    public void ResetScoreImage()
    {
        RightImages.SetText("");
        WrongImages.SetText("");
        RawScoreText.SetText("");
        TimeLeftMultiplier.SetText("");
        PerfectRoundMulti.SetText("");
        TotalRoundScore.SetText("");
    }

}

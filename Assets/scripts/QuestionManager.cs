using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;


public class QuestionManager : MonoBehaviour
{
    
    public Text questionText;
    public Text scoreText;
    public static int score;
    public Text rightWrongText;
    public Image image;
    public Button[] answerButtons;
    public questions questionScript;
    int currentQuestion;
    public GameObject gameOver;
    public Text finalScore;
    public GameObject mainCamera;




    void SetQuestion(int questionIndex)
    {
        //Question
        questionText.text = questionScript.question[questionIndex].questionText;
        //Images
        image.sprite = questionScript.question[questionIndex].image;

      //  Vector2 spriteOriginSize = questionScript.question[questionIndex].image.rect.size;
       // Vector2 maxSize = new Vector2(900, 800);
        
        

        
       // spriteOriginSize = spriteOriginSize * 0.5f;
      //  image.GetComponent<RectTransform>().sizeDelta = spriteOriginSize;

       
        
        

        //Answers
      
       for (int i = 0; i < answerButtons.Length; i++ ) 
       {
        answerButtons[i].GetComponentInChildren<Text>().text = questionScript.question[questionIndex].answers[i];
        answerButtons[i].onClick.RemoveAllListeners();

        int answerIndex = i;

        answerButtons[i].onClick.AddListener(() => { CheckAnswer(answerIndex); });

       }

    }

    void CheckAnswer(int answerIndex)
    {
        for (int i = 0; i < answerButtons.Length; i++ ) 
       {
        
        answerButtons[i].onClick.RemoveAllListeners();

       

       }

        foreach (Button answer in answerButtons)
        {
            answer.interactable = false;
            answerButtons[questionScript.question[currentQuestion].correctAnswer].interactable = true;     
            answer.GetComponentInChildren<Text>().color = Color.red;
            answerButtons[questionScript.question[currentQuestion].correctAnswer].GetComponentInChildren<Text>().color = Color.green;
                
        }


        if(answerIndex == questionScript.question[currentQuestion].correctAnswer)
        {
            print("right anwser");
            rightWrongText.text = "sworiaa";
            
            
            rightWrongText.color = Color.green;
            rightWrongText.transform.parent.gameObject.SetActive(true);
            score++;
            scoreText.text = score.ToString();
            StartCoroutine(NextQuestion());

        }
        else
        {
            print("wrong answer");
            rightWrongText.text = "looooser :B";
            
            rightWrongText.color =  Color.red;
            rightWrongText.transform.parent.gameObject.SetActive(true);

            StartCoroutine(NextQuestion());


        }
        
        

    }

    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(2);
        rightWrongText.color =  Color.gray;
        rightWrongText.transform.parent.gameObject.SetActive(false);

         foreach (Button answer in answerButtons)
        {
            answer.interactable = true;
            answer.GetComponentInChildren<Text>().color = Color.black;
            
            
        }
        currentQuestion++;

        if(currentQuestion < questionScript.question.Length)
        {
            SetQuestion(currentQuestion);

        }
        else
        {
            gameOver.SetActive(true);
            finalScore.text = "Final score - " + score + " Great job";
        }
    }
   

    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        SetQuestion(currentQuestion);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

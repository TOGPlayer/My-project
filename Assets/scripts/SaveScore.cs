using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;



public class SaveScore : MonoBehaviour
{

    public InputField nameInput;
    public UnityEvent<string, int> saveScoreAndName;

    public void SaveScoreName()
    {
        saveScoreAndName.Invoke(nameInput.text, QuestionManager.score);
        GetComponent<Button>().interactable = false;
       

    }
    public void ButtonEnable()
    {
         GetComponent<Button>().interactable = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

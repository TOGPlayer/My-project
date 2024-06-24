using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Questions", menuName = "New ScriptableObjact")]
public class questions : ScriptableObject
{
    [System.Serializable]
    public struct Questions
    {
        public string questionText;
        public Sprite image;
        public string[] answers;
        public int correctAnswer;

    }
    public Questions[] question;
}

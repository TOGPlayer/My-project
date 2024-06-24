using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;
using System;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    List<Text> names;
    [SerializeField]
    List<Text> scores;
    [SerializeField]
    List<string> usedNames;
    
    public GameObject popOut;
    public SaveScore saveScoreScript;
    
    string leaderBoardPublicKey = "704601c21662f8c3ee14de9e7bf9122034437e22ddc7657907776ea1b2897f18";

    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(leaderBoardPublicKey, ((msg) => 
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for(int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
                if (!usedNames.Contains(msg[i].Username))
                {
                    usedNames.Add(msg[i].Username);
                }

            }

        }));
    }
    public void UploadLiderBoard(string username, int score)
    {
        
        if (CheckUsername(username))
        {
            StartCoroutine(PopUpText());

            print("username already exist");
        

            return;

        }
        
        

        LeaderboardCreator.UploadNewEntry(leaderBoardPublicKey, username, score, ((msg) => { GetLeaderBoard(); }));
        LeaderboardCreator.ResetPlayer();
        
        
    }
    IEnumerator PopUpText()
    {
        popOut.SetActive(true);
        yield return new WaitForSeconds(1);
         popOut.SetActive(false);
        saveScoreScript.ButtonEnable();


    }
    public bool CheckUsername(string username)
    {
        return usedNames.Contains(username);
    }
    public void CheckUserName()
    {
        
    }
   


    // Start is called before the first frame update
    void Start()
    {
        GetLeaderBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
}

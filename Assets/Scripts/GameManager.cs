using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public string name;
    public TextMeshProUGUI textDisp;
    public TextMeshProUGUI textname;
    public GameObject inputField;
  

   

    // Start is called before the first frame update
    void Start()
    {
        if (saveManager.instance != null)
        {
            textDisp.text = saveManager.instance.HighScorerName +" : "+ "highscore : " + saveManager.instance.highscore;
            //name = saveManager.instance.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playername();
    }

    void playername()
    {         
        name = textname.GetComponent<TextMeshProUGUI>().text;
        saveManager.instance.setName(name);
       
    }


    public void displayPlayerName()
    {
        textDisp.GetComponent<TextMeshProUGUI>().text = "welcome " + name;
    }
    public void ToGameScene()
    {
        SceneManager.LoadScene(1);
    }

 

    public void quit()
    {
        saveManager.instance.SavePlayerData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
                        Application.Quit(); // original code to quit Unity player
        #endif


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class saveManager : MonoBehaviour
{

    public static saveManager instance;
    public int highscore;
    public string name;
    public string HighScorerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        loadPlayerData();
    }
 

    public void setHighscore(int H_score,string H_name)
    {
        saveManager.instance.highscore = H_score;
        saveManager.instance.HighScorerName = H_name;
    }

    public void setName(string name)
    {
        saveManager.instance.name = name;
    }

    [System.Serializable]
    public class SaveData
    {
        public int playerScore;
        public string playerName;
    }

    public void SavePlayerData()
    {
        SaveData playerData = new SaveData();
        playerData.playerScore = highscore;
        playerData.playerName = HighScorerName;

        string myPlayerData = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", myPlayerData);
    }

    public void loadPlayerData()
    {
        string path = Application.persistentDataPath + "/saveFile.json";

        if (path != null)
        {
            string myplayerData = File.ReadAllText(path);
            SaveData playerData = JsonUtility.FromJson<SaveData>(myplayerData);

            highscore = playerData.playerScore;
            HighScorerName = playerData.playerName;
        }
    }
}

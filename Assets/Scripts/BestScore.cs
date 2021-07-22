using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    public static BestScore Instance;

    public int BestScoreResult { get; private set; } = 0;
    public string BestPlayerName { get; private set; } = "";

    private void Awake()
    {

        if ( Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    public void CheckResult(int newScore, string playerName)
    {
        if (newScore > BestScoreResult)
        {
            BestScoreResult = newScore;
            BestPlayerName = playerName;
            SaveBestScore();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestPlayerName;
    }

    private void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.BestScore = BestScoreResult;
        data.BestPlayerName = BestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile2.json", json);
    }

    private void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile2.json";
        Debug.Log(Application.persistentDataPath + "/savefile2.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScoreResult = data.BestScore;
            BestPlayerName = data.BestPlayerName;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager1 : MonoBehaviour
{
    public static MainManager1 Instance;
    public string highName;
    public string name;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        LoadData();
    }

    void Update()
    {

    }

    public void ReadString(string s)
    {
        name = s;
        Debug.Log(name);
    }

    public string getName() { return highName; }
    public int gethighScore() { return highScore; }

    public void sethighScore(int x)
    {
        highScore = x;
    }

    public void sethighName(string y)
    {
        highName = y;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highName = highName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + " /savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + " /savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highName = data.highName;
        }
    }


    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highName;
    }
}


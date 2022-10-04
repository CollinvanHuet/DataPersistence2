using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public static MenuUIHandler instance;
    public SavableData _bestScore;
    
    [Serializable]
    public struct SavableData
    {
        
        public int score;
        public string name;
    }

    [SerializeField] public SavableData _data;
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);
        _data = new SavableData();
        try
        {
            _bestScore =
                JsonUtility.FromJson<SavableData>(File.ReadAllText(Application.persistentDataPath + "/save.json"));
        }
        catch (Exception unused)
        {
            _bestScore = new SavableData
            {
                score = -1
            };
        }
    }
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        var json = JsonUtility.ToJson(_bestScore, true);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }
}

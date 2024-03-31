using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    [Serializable]
    public class Data
    {
        public List<ulong> bestScores;
    }

    private Data data;

    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Rhythm-Hunter.data");
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(this.data);

        File.WriteAllText(savePath, data);
    }

    public void Load()
    {
        string data = File.ReadAllText(savePath);

        this.data = JsonUtility.FromJson<Data>(data);
    }
}

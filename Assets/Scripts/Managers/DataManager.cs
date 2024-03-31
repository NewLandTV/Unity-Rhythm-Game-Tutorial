using Newtonsoft.Json;
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
        public Dictionary<int, ulong> bestScores;
    }

    private Data data = new Data();

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

        data.bestScores = new Dictionary<int, ulong>();

        savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Rhythm-Hunter.data");
    }

    public void Save()
    {
        string data = JsonConvert.SerializeObject(this.data);

        File.WriteAllText(savePath, data);
    }

    public void Load()
    {
        if (!File.Exists(savePath))
        {
            return;
        }

        string data = File.ReadAllText(savePath);

        this.data = JsonConvert.DeserializeObject<Data>(data);

        if (this.data == null)
        {
            this.data = new Data();
            this.data.bestScores = new Dictionary<int, ulong>();
        }
    }

    public bool ContainsBestScore(int index) => data.bestScores.ContainsKey(index);

    public ulong GetBestScore(int index) => data.bestScores[index];

    public void SetBestScore(int index, ulong score) => data.bestScores[index] = score;
}

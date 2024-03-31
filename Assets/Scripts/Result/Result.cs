using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    public static ulong score;

    [SerializeField]
    private TextMeshProUGUI totalScore;

    private void Start()
    {
        int id = CurrentStage.data.id;
        bool contains = DataManager.Instance.ContainsBestScore(id);

        if (!contains || DataManager.Instance.GetBestScore(id) < score)
        {
            DataManager.Instance.SetBestScore(id, score);
        }

        DataManager.Instance.Save();
        SoundManager.Instance.PlaySFX("Stage Clear");

        totalScore.text = $"{score:n0}";
        score = 0;
    }

    public void GoLobby()
    {
        SoundManager.Instance.PlaySFX("Button Click");
        Loading.LoadScene(Scene.Lobby);
    }
}

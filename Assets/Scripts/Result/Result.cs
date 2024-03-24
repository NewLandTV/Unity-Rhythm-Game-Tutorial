using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    public static ulong score;

    [SerializeField]
    private TextMeshProUGUI totalScore;

    private void Start()
    {
        SoundManager.Instance.PlaySFX("Stage Clear");

        totalScore.text = $"{score:n0}";
    }

    public void GoLobby()
    {
        Loading.LoadScene(Scene.Lobby);
    }
}

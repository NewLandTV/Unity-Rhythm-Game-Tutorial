using TMPro;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI version;

    private void Awake()
    {
        version.text = $"v{Application.version}";
    }

    private void Start()
    {
        DataManager.Instance.Load();
        SoundManager.Instance.PlayBGM("AxR", true);
    }

    public void StartGame()
    {
        SoundManager.Instance.PlaySFX("Button Click");
        SoundManager.Instance.StopBGM();
        Loading.LoadScene(Scene.Lobby);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

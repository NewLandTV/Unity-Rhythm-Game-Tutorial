using UnityEngine;

public class Title : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayBGM("AxR", true);
    }

    public void StartGame()
    {
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

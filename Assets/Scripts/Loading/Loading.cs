using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scene
{
    Title = 0,
    Loading = 1,
    Lobby = 2,
    Game = 3,
    Result = 4
}

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Image progressBar;

    private static Scene targetScene;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    public static void LoadScene(Scene targetScene)
    {
        Loading.targetScene = targetScene;

        SceneManager.LoadScene((int)Scene.Loading);
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync((int)targetScene);

        operation.allowSceneActivation = false;

        float time = 0f;

        while (!operation.isDone)
        {
            float value = 0f;

            if (operation.progress < 0.9f)
            {
                value = operation.progress;
            }
            else
            {
                value = Mathf.Lerp(0.9f, 1f, time);
                time += Time.unscaledDeltaTime;
            }

            progressBar.fillAmount = value;

            if (value >= 1f)
            {
                operation.allowSceneActivation = true;

                yield break;
            }

            yield return null;
        }
    }
}

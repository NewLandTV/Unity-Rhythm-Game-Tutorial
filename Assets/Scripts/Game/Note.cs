using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Note : MonoBehaviour
{
    public float dropSpeed;

    public RectTransform judgeLine;
    public RectTransform disablePoint;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        rectTransform.anchoredPosition = Vector3.zero;
    }

    private void Update()
    {
        rectTransform.anchoredPosition += Vector2.down * dropSpeed * Time.deltaTime;

        float y = rectTransform.position.y;

        if (judgeLine != null && y - 288f <= judgeLine.position.y)
        {
            judgeLine = null;

            SoundManager.Instance.PlayBGM(CurrentStage.data.bgmName, onEnd: () => Loading.LoadScene(Scene.Result));
        }

        if (y <= disablePoint.position.y)
        {
            Initialize();
        }
    }

    public void Initialize()
    {
        gameObject.SetActive(false);

        rectTransform.anchoredPosition = Vector3.zero;
    }
}

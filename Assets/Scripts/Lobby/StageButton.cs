using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI bgmName;

    private void Awake()
    {
        button = GetComponent<Button>();
        bgmName = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Setup(Stage stage, Action onButtonClick)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onButtonClick?.Invoke());

        bgmName.text = stage.bgmName;

        gameObject.SetActive(true);
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    private List<StageButton> buttonPooling;

    [SerializeField]
    private StageButton buttonPrefab;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private int makeCount;

    [SerializeField]
    private GameObject infoGroup;
    [SerializeField]
    private TextMeshProUGUI infoArtistBgmName;
    [SerializeField]
    private TextMeshProUGUI infoCreatorName;

    private void Awake()
    {
        buttonPooling = new List<StageButton>(makeCount);

        for (int i = 0; i < makeCount; i++)
        {
            MakeButton();
        }
    }

    private StageButton MakeButton()
    {
        StageButton instance = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, parent);

        instance.gameObject.SetActive(false);

        buttonPooling.Add(instance);

        return instance;
    }

    public void SetupButton(Stage stage)
    {
        for (int i = buttonPooling.Count - 1; i >= 0; i--)
        {
            if (!buttonPooling[i].gameObject.activeSelf)
            {
                buttonPooling[i].Setup(stage, () => ShowInfoGroup(stage));

                return;
            }
        }

        StageButton newButton = MakeButton();

        newButton.Setup(stage, () => ShowInfoGroup(stage));
    }

    public void ShowInfoGroup(Stage stage)
    {
        CurrentStage.data = stage;

        SoundManager.Instance.PlayBGM(stage.bgmName, true);

        infoArtistBgmName.text = $"{stage.artistName} - {stage.bgmName}";
        infoCreatorName.text = stage.creatorName;

        infoGroup.SetActive(true);
    }

    public void GamePlay()
    {
        SoundManager.Instance.StopBGM();
        Loading.LoadScene(Scene.Game);
    }
}

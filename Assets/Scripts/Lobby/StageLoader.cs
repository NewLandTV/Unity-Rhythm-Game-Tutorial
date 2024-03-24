using UnityEngine;

public class StageLoader : MonoBehaviour
{
    [SerializeField]
    private StageUI ui;

    public void LoadStage(Stage stage)
    {
        ui.SetupButton(stage);
    }

    public void LoadStages(StageData data)
    {
        for (int i = 0; i < data.Stages.Length; i++)
        {
            LoadStage(data.Stages[i]);
        }
    }
}

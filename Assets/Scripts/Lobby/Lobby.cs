using UnityEngine;

public class Lobby : MonoBehaviour
{
    [SerializeField]
    private StageLoader loader;
    [SerializeField]
    private StageData data;

    private void Start()
    {
        loader.LoadStages(data);
    }
}

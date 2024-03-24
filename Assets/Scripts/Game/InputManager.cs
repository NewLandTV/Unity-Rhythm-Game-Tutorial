using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private void Update()
    {
        if (!Input.anyKeyDown)
        {
            return;
        }

        gameManager.JudgeNote();
    }
}

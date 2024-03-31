using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Animator titleGroup;
    [SerializeField]
    private TextMeshProUGUI titleMessage;
    private WaitForSeconds waitTime1f = new WaitForSeconds(1f);
    private WaitForSeconds waitTime4f = new WaitForSeconds(4f);

    [SerializeField]
    private NoteManager noteManager;

    [SerializeField]
    private TextMeshProUGUI totalScore;
    [SerializeField]
    private TextMeshProUGUI judgeText;

    private bool start;

    private WaitForSeconds notePerSecond;

    private IEnumerator Start()
    {
        ShowTitleGroup($"{CurrentStage.data.artistName} - {CurrentStage.data.bgmName}");

        yield return HideTitleGroup();

        start = true;
        notePerSecond = new WaitForSeconds(60f / CurrentStage.data.bpm);

        while (true)
        {
            SoundManager.Instance.PlaySFX("Beat");

            noteManager.DropNote();

            yield return notePerSecond;
        }
    }

    private void LateUpdate()
    {
        totalScore.text = $"SCORE {Result.score:n0}";
    }

    public void ShowTitleGroup(string message)
    {
        titleGroup.gameObject.SetActive(true);
        titleGroup.SetTrigger("Show");

        titleMessage.text = message;
    }

    private IEnumerator HideTitleGroup()
    {
        yield return waitTime4f;

        titleGroup.SetTrigger("Hide");

        yield return waitTime1f;

        titleGroup.gameObject.SetActive(false);
    }

    public void JudgeNote()
    {
        if (!start)
        {
            return;
        }

        SoundManager.Instance.PlaySFX("Judge");

        JudgementResult result = noteManager.GetJudgementResultOfNearestNote();

        judgeText.text = $"{result}";

        switch (result)
        {
            case JudgementResult.Perfect:
                Result.score += 100;

                break;
            case JudgementResult.Great:
                Result.score += 80;

                break;
            case JudgementResult.Good:
                Result.score += 50;

                break;
            case JudgementResult.Normal:
                Result.score += 25;

                break;
            case JudgementResult.Bad:
                Result.score += 5;

                break;
            case JudgementResult.Miss:
                break;
        }
    }
}

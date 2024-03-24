using System.Collections.Generic;
using UnityEngine;

public enum JudgementResult
{
    Perfect,
    Great,
    Good,
    Normal,
    Bad,
    Miss
}

public class NoteManager : MonoBehaviour
{
    private List<Note> notePooling;

    [SerializeField]
    private Note prefab;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private int makeCount;

    [SerializeField]
    private RectTransform judgeLine;
    [SerializeField]
    private RectTransform disablePoint;

    private bool firstNote = true;

    private void Awake()
    {
        notePooling = new List<Note>(makeCount);

        for (int i = 0; i < makeCount; i++)
        {
            MakeNote();
        }
    }

    private void MakeNote()
    {
        Note instance = Instantiate(prefab, Vector3.zero, Quaternion.identity, parent);

        instance.gameObject.SetActive(false);

        notePooling.Add(instance);
    }

    public void DropNote()
    {
        for (int i = notePooling.Count - 1; i >= 0; i--)
        {
            if (!notePooling[i].gameObject.activeSelf)
            {
                if (firstNote)
                {
                    firstNote = false;
                    notePooling[i].judgeLine = judgeLine;
                }

                notePooling[i].disablePoint = disablePoint;
                notePooling[i].dropSpeed = CurrentStage.data.noteDropSpeed;

                notePooling[i].gameObject.SetActive(true);

                return;
            }
        }
    }

    public JudgementResult GetJudgementResultOfNearestNote()
    {
        float sqrMagnitude = float.MaxValue;
        int targetNoteIndex = -1;

        for (int i = notePooling.Count - 1; i >= 0; i--)
        {
            float value = (notePooling[i].transform.position - judgeLine.position).sqrMagnitude;

            if (value < sqrMagnitude)
            {
                sqrMagnitude = value;
                targetNoteIndex = i;
            }
        }

        if (sqrMagnitude <= 256f)
        {
            notePooling[targetNoteIndex].Initialize();

            return JudgementResult.Perfect;
        }
        if (sqrMagnitude <= 1024f)
        {
            notePooling[targetNoteIndex].Initialize();

            return JudgementResult.Great;
        }
        if (sqrMagnitude <= 4096f)
        {
            notePooling[targetNoteIndex].Initialize();

            return JudgementResult.Good;
        }
        if (sqrMagnitude <= 16384f)
        {
            notePooling[targetNoteIndex].Initialize();

            return JudgementResult.Normal;
        }
        if (sqrMagnitude <= 65536f)
        {
            notePooling[targetNoteIndex].Initialize();

            return JudgementResult.Bad;
        }

        return JudgementResult.Miss;
    }
}

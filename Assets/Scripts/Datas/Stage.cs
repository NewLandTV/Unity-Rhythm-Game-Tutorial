using UnityEngine;

[CreateAssetMenu(fileName = "My Stage", menuName = "New Stage")]
public class Stage : ScriptableObject
{
    public string bgmName;
    public string artistName;
    public string creatorName;
    [Range(1, 10)]
    public int difficulty = 1;
    public int bpm = 100;
    public float noteDropSpeed = 500f;
}

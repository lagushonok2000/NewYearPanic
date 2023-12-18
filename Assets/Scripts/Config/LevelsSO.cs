using UnityEngine;

[CreateAssetMenu(fileName = "LevelsSO", menuName = "Config/LevelsSO", order = 0)]
public class LevelsSO : ScriptableObject
{
    public int[] KristallsOnLevel;
    public float[] TimeOnLevel;
    public float[] PlayerSpeed;
    public float[] PlayerHP;
    public float[] PlayerDamage;
    public float[] EnemyDamage;
}
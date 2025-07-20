using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "ScriptableObjects/MonsterData", order = 2)]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public int hp;
    public int mp;
    public int atk;
    public int mag;
    public int def;
    public int mdef;
    public int spd;

    public GameObject dropItem;

    public int stageId;
}

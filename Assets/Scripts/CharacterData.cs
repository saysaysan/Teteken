using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/CharacterData", order = 1)]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int hp;
    public int mp;
    public int atk;
    public int mag;
    public int def;
    public int mdef;
    public int spd;
}

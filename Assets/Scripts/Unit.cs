using UnityEngine;

public class Unit : MonoBehaviour
{
    public CharacterData characterData;
    public MonsterData monsterData;

    public int CurrentHp { get; private set; }
    public int CurrentMp { get; private set; }

    public int SPD
    {
        get
        {
            if (characterData != null)
                return characterData.spd;
            if (monsterData != null)
                return monsterData.spd;
            return 0;
        }
    }

    void Awake()
    {
        if (characterData != null)
        {
            CurrentHp = characterData.hp;
            CurrentMp = characterData.mp;
        }
        else if (monsterData != null)
        {
            CurrentHp = monsterData.hp;
            CurrentMp = monsterData.mp;
        }
    }

    public void TakeDamage(int dmg)
    {
        CurrentHp = Mathf.Max(CurrentHp - dmg, 0);
    }
}

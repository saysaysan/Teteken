using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public List<Unit> playerParty;
    public List<Unit> enemyParty;

    private Queue<Unit> turnQueue;

    void Start()
    {
        InitializeBattle();
        StartCoroutine(BattleLoop());
    }

    void InitializeBattle()
    {
        List<Unit> allUnits = new List<Unit>();
        allUnits.AddRange(playerParty);
        allUnits.AddRange(enemyParty);
        turnQueue = new Queue<Unit>(allUnits.OrderByDescending(u => u.SPD));
    }

    System.Collections.IEnumerator BattleLoop()
    {
        while (playerParty.Any(u => u.CurrentHp > 0) && enemyParty.Any(u => u.CurrentHp > 0))
        {
            if (turnQueue.Count == 0)
            {
                InitializeBattle();
            }
            Unit current = turnQueue.Dequeue();
            if (current.CurrentHp <= 0)
            {
                continue;
            }

            yield return ExecuteTurn(current);
        }

        Debug.Log("Battle Finished");
    }

    System.Collections.IEnumerator ExecuteTurn(Unit unit)
    {
        // Simple auto-attack logic for placeholder
        Unit target = (enemyParty.Contains(unit)) ? playerParty.FirstOrDefault(u => u.CurrentHp > 0) : enemyParty.FirstOrDefault(u => u.CurrentHp > 0);
        if (target == null) yield break;

        int attack = 0;
        int defense = 0;

        if (unit.characterData != null)
        {
            attack = unit.characterData.atk;
        }
        else if (unit.monsterData != null)
        {
            attack = unit.monsterData.atk;
        }

        if (target.characterData != null)
        {
            defense = target.characterData.def;
        }
        else if (target.monsterData != null)
        {
            defense = target.monsterData.def;
        }

        int damage = Mathf.Max(attack - defense, 1);
        target.TakeDamage(damage);
        Debug.Log($"{unit.name} attacks {target.name} for {damage} damage");
        yield return new WaitForSeconds(1f);
    }
}

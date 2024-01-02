using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    
    public void HandleCombatTurn(Creature offensiveCreature, Creature attackedCreature)
    {
        if (!offensiveCreature.IsAlive() || !attackedCreature.IsAlive())
            return;

        if (offensiveCreature.CurrentSPD >= attackedCreature.CurrentSPD)
        {
            IIDamageable damagebleAttackedCreature = attackedCreature as IIDamageable;
            if (damagebleAttackedCreature != null)
            {
                damagebleAttackedCreature.TakeDamage(offensiveCreature.CurrentATK);
            }

            IIDamageable damagebleOffensiveCreature = offensiveCreature as IIDamageable;
            if (damagebleOffensiveCreature != null)
            {
                damagebleOffensiveCreature.TakeDamage(attackedCreature.CurrentATK);
            }
        }
        else
        {
            IIDamageable damagebleOffensiveCreature = offensiveCreature as IIDamageable;
            if (damagebleOffensiveCreature != null)
            {
                damagebleOffensiveCreature.TakeDamage(attackedCreature.CurrentATK);
            }

            IIDamageable damagebleAttackedCreature = attackedCreature as IIDamageable;
            if (damagebleAttackedCreature != null)
            {
                damagebleAttackedCreature.TakeDamage(offensiveCreature.CurrentATK);
            }
        }
    }
}

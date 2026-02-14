using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCalculator
{
    public int GetConModifier(int conScore)
    {
        int conModifier = 0;
        // ConModifier determination
        if (conScore == 1)
        {
            conModifier = -5;
        }
        else if (conScore <= 3)
        {
            conModifier = -4;
        }
        else if (conScore <= 5)
        {
            conModifier = -3;
        }
        else if (conScore <= 7)
        {
            conModifier = -2;
        }
        else if (conScore <= 9)
        {
            conModifier = -1;
        }
        else if (conScore <= 11)
        {
            conModifier = 0;
        }
        else if (conScore <= 13)
        {
            conModifier = 1;
        }
        else if (conScore <= 15)
        {
            conModifier = 2;
        }
        else if (conScore <= 17)
        {
            conModifier = 3;
        }
        else if (conScore <= 19)
        {
            conModifier = 4;
        }
        else if (conScore <= 21)
        {
            conModifier = 5;
        }
        else if (conScore <= 23)
        {
            conModifier = 6;
        }
        else if (conScore <= 25)
        {
            conModifier = 7;
        }
        else if (conScore <= 27)
        {
            conModifier = 8;
        }
        else if (conScore <= 29)
        {
            conModifier = 9;
        }
        else if (conScore == 30)
        {
            conModifier = 10;
        }

        return conModifier;
    }

    public float CalculateBaseHP(int level, int hitDie, int conModifier, bool average)
    {
        float totalHP = hitDie + conModifier;

        // If average was picked
        if (average == true)
        {
            for (int i = 1; i < level; i++)
            {
                // Average Hit for the picked die for each level
                float averageHit = (hitDie / 2.0f) + 0.5f;
                // Add to total HP
                totalHP += averageHit + conModifier;
            }
        }
        // If average wasn't picked
        else
        {
            for (int i = 1; i < level; i++)
            {
                // Random roll for the picked die for each level
                int roll = Random.Range(1, hitDie + 1);
                // Add to total HP
                totalHP += roll + conModifier;
            }
        }

        return totalHP;
    }

    public float GetRaceBonus(string race, int level)
    {
        float raceBonus = 0;

        // Dwarf race adds 2 HP bonus per level
        if (race == "Dwarf")
        {
            raceBonus += 2 * level;
        }
        // Orc race adds 1 HP bonus per level
        else if (race == "Orc")
        {
            raceBonus += 1 * level;
        }
        // Goliath race adds 1 HP bonus per level
        else if (race == "Goliath")
        {
            raceBonus += 1 * level;
        }

        return raceBonus;
    }

    public float GetFeatBonus(bool hasTough, bool hasStout, int level)
    {
        float bonus = 0;

        // If hasTough is picked
        if (hasTough == true)
        {
            bonus += 2 * level;
        }

        // if hasStout is picked
        if (hasStout == true)
        {
            bonus += 1 * level;
        }

        return bonus;
    }
}

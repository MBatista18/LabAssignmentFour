using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnD5eHPCalculator : MonoBehaviour
{
    // ClassToDie Dictionary
    Dictionary<string, int> classToDie = new Dictionary<string, int>();

    // Variables
    public string characterName;
    public int level;
    public string characterClass;
    public int conScore;
    public string race;
    public bool hasTough;
    public bool hasStout;
    public bool average;

    void Start()
    {
        // Sets up class die dictionary
        SetupClassDictionary();

        // If class isn't in the dictionary
        if (!classToDie.ContainsKey(characterClass))
        {
            Debug.LogError("Invalid class name!");
            return;
        }

        // Level can't go above 20
        if (level > 20)
        {
            Debug.LogError("Invalid level!");
            return;
        }

        // ConScore can't go above 30
        if (conScore > 30)
        {
            Debug.LogError("Invalid conScore!");
            return;
        }

        // Picks the appropriate die
        int hitDie = classToDie[characterClass];

        // Picks the appropriate modifier based on score
        int conModifier = GetConModifier();
        
        // Finds out the base HP using just the die and the modifier
        float totalHP = CalculateBaseHP(hitDie, conModifier);

        // Bonuses from race and feats added to total HP
        totalHP += GetRaceBonus();
        totalHP += GetFeatBonus();

        Debug.Log($"My character {characterName} is a level {level} {characterClass} with a CON score of {conScore} and is of {race} race. Tough feat is {hasTough}. Stout feat is {hasStout}. I want the HP {average}. True = Average; False = Rolled");
        Debug.Log($"Total HP: {totalHP}");
    }

    void SetupClassDictionary()
    {
        // Determine what class the player chose
        classToDie.Add("Artificier", 8);
        classToDie.Add("Barbarian", 12);
        classToDie.Add("Bard", 8);
        classToDie.Add("Cleric", 8);
        classToDie.Add("Druid", 8);
        classToDie.Add("Fighter", 10);
        classToDie.Add("Monk", 8);
        classToDie.Add("Ranger", 10);
        classToDie.Add("Rogue", 8);
        classToDie.Add("Paladin", 10);
        classToDie.Add("Sorcerer", 6);
        classToDie.Add("Wizard", 6);
        classToDie.Add("Warlock", 8);
    }

    int GetConModifier()
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

    float CalculateBaseHP(int hitDie, int conModifier)
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

    float GetRaceBonus()
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

    float GetFeatBonus()
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

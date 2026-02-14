using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionTwo : MonoBehaviour
{
    // Holds the character data entered in the Inspector
    public CharacterData character;

    // Stores the selected character class
    private CharacterClass characterClass;
    // Handles all HP-related calculations
    private HPCalculator calculator = new HPCalculator();

    // Enum listing all selectable character classes
    public enum ClassType
    {
        Artificier, Barbarian, Bard, Cleric, Druid, Fighter, Monk, Paladin, Ranger, Rogue, Sorcerer, Warlock, Wizard
    }

    // Instantiates the correct class type based on Inspector selection
    public ClassType selectedClass;

    void Start()
    {
        switch (selectedClass)
        {
            case ClassType.Artificier:
                characterClass = new Artificier();
                break;
            
            case ClassType.Barbarian:
                characterClass = new Barbarian();
                break;

            case ClassType.Bard:
                characterClass = new Bard();
                break;

            case ClassType.Cleric:
                characterClass = new Cleric();
                break;

            case ClassType.Druid:
                characterClass = new Druid();
                break;

            case ClassType.Fighter:
                characterClass = new Fighter();
                break;

            case ClassType.Monk:
                characterClass = new Monk();
                break;

            case ClassType.Paladin:
                characterClass = new Paladin();
                break;

            case ClassType.Ranger:
                characterClass = new Ranger();
                break;

            case ClassType.Rogue:
                characterClass = new Rogue();
                break;

            case ClassType.Sorcerer:
                characterClass = new Sorcerer();
                break;

            case ClassType.Warlock:
                characterClass = new Warlock();
                break;

            case ClassType.Wizard:
                characterClass = new Wizard();
                break;
        }

        // Level can't go above 20
        if (character.level > 20)
        {
            Debug.LogError("Invalid level!");
            return;
        }

        // ConScore can't go above 30
        if (character.conScore > 30)
        {
            Debug.LogError("Invalid conScore!");
            return;
        }

        // Grabs hit die from selected class
        int hitDie = characterClass.GetHitDie();
        // Calculate Constitution modifier
        int conModifier = calculator.GetConModifier(character.conScore);

        // Calculate base HP using level, hit die, and Constitution modifier
        float baseHP = calculator.CalculateBaseHP(character.level, hitDie, conModifier, character.average);

        // Calculate race-based HP bonus
        float raceBonus = calculator.GetRaceBonus(character.race, character.level);
        // Calculate HP bonus from selected feats
        float featBonus = calculator.GetFeatBonus(character.hasTough, character.hasStout, character.level);

        // Store HP breakdown in HPResult struct
        HPResult result;
        result.baseHP = baseHP;
        result.raceBonus = raceBonus;
        result.featBonus = featBonus;
        result.totalHP = baseHP + raceBonus + featBonus;

        Debug.Log($"My character {character.characterName} is a level {character.level} {characterClass} with a CON score of {character.conScore} and is of {character.race} race. Tough feat is {character.hasTough}. Stout feat is {character.hasStout}. I want the HP {character.average}. True = Average; False = Rolled");
        Debug.Log($"Total HP: {result.totalHP}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterProperty : ScriptableObject
{
    public string characterName;
    public Sprite Icon;
    public int maxHp;
    public int attack;
    public int defense;
    public int speed;
}

public class CardData:ScriptableObject
{
    public string cardName;
    public Sprite Icon;
    public CommandType commandType;
    public int skillId;
}
public class CombatUnit
{
    CombatUnit(CharacterProperty property):this(property,0)
    {
    }

    CombatUnit(CharacterProperty property,int sp)
    {
        this.property = property;
        currentHp = property.maxHp;
        currentSp = sp;
        currentSpeed = property.speed;
    }
    public CharacterProperty property;
    public int currentHp;
    public int currentSp; // Õ½¼¼µã / EP
    public int currentSpeed;
    public bool isDead => currentHp <= 0;
    public List<CardData> handCards = new();
}
public enum CommandType
{
    Attack,
    Defend,
    Skill,
    Item,
    Await
}

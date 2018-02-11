using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Card Data", menuName = "Card/New Card", order = 1)]
public class CardData : ScriptableObject 
{
	//Attributes from a card
    public new string name;
    public int manaCost;
    public int health;
    public int attack;
    public Type type;
    public HeroClass heroClass;
    public Effect[] effects;

    public enum Effect
    {
        Battlecry,Deathrattle,EndOfTurn,Poison,SpellQuestionMark
    }

    public bool IsMinion
    {
        get{return this.type != Type.Spell?true:false;}
    }

    public enum Type
    {
        Murloc,Beast,Demon,Spell
    }
}

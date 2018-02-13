namespace Logic
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using System.Linq;

public class PlayerBoard
{
    public List<CardData> minions = new List<CardData>();

	public PlayerBoard()
	{
		this.minions = new List<CardData>(Game.BoardSize);
	}

    public void SummonMinion(CardData card)
    {
        this.minions.Add(card);
        //card.BattleCry();
    }

	public CardData MostPowerfulMinion
	{
		get
		{
			return this.minions.Aggregate((minion1,minion2)=>
			{
				return minion1.attack>minion2.attack?minion1:minion2;
			});
		}
	}

	public CardData MostHealthyMinion
	{
		get
		{
			return this.minions.Aggregate((minion1,minion2)=>
			{
				return minion1.health>minion2.health?minion1:minion2;
			});
		}
	}

    public string Show()
	{
		var message="\n";
		foreach(var card in minions)
		{
			message+=$"{card.manaCost} {card.name} {card.attack}/{card.health} \n";
		}
		return message;
	}
}

}
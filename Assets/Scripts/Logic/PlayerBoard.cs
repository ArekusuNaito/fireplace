namespace Logic
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using System.Linq;

public class PlayerBoard
{
    public List<Minion> minions = new List<Minion>();

	public PlayerBoard()
	{
		this.minions = new List<Minion>(Game.BoardSize);
	}

    public Minion SummonMinion(Card card)
    {
		Minion minion = new Minion(card);
        this.minions.Add(minion);
        //card.BattleCry();
		return minion;
    }

	public void Remove(Minion minion)
	{
		this.minions.Remove(minion);
	}

	public Minion FindMinion(Minion minion)
	{
		return this.minions.Find(queryMinion=> minion==queryMinion);
	}

	public Minion MostPowerfulMinion
	{
		get
		{
			return this.minions.Aggregate((minion1,minion2)=>
			{
				return minion1.attack>minion2.attack?minion1:minion2;
			});
		}
	}

	public int Count
	{
		get{return this.minions.Count;}
	}

	public Minion MostHealthyMinion
	{
		get
		{
			return this.minions.Aggregate((minion1,minion2)=>
			{
				return minion1.health>minion2.health?minion1:minion2;
			});
		}
	}
}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand 
{
	private List<CardData> cards = new List<CardData>();
	public int maxSize = 10; //Your hand cannot exceed this

	public Hand()
	{
		
	}

	public int Count
	{
		get{return this.cards.Count;}
	}
	public bool IsFull
	{
		get{
			return (this.cards.Count>=maxSize);
		}
	}

	public string Show()
	{
		var message="\n";
		foreach(var card in cards)
		{
			message+=$"{card.manaCost} {card.name} {card.attack}/{card.health} \n";
		}
		return message;
	}

	public void Add(CardData card)
	{
		this.cards.Add(card);
	}
}

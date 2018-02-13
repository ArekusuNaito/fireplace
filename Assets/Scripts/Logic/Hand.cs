namespace Logic
{
	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand 
{
	private List<Card> cards = new List<Card>();
	public int maxSize = 10; //Your hand cannot exceed this

	public Hand()
	{
		
	}

	public Card FindCard(string cardName)
	{
		foreach(var cardData in this.cards)
		{
			if(cardData.name.ToLower() == cardName.ToLower())return cardData;
		}
		return null;
	}

	public void Remove(Card cardData)
	{
		this.cards.Remove(cardData);
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

	public void Add(Card card)
	{
		this.cards.Add(card);
	}
}

}
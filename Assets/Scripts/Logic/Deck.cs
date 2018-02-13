namespace Logic
{
	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck 
{
	public int maxSize=30;
	private List<Card> cards = new List<Card>();
	private int drawIndex=0;

	Hand hand;

	public Deck()
	{
		GenerateRandomDeck(); 
		//this.Shuffle should happen as well, when there's more cards in the Database
	}
	
	//I'm aware that Hand and deck share methods.
	//This is one of them
	public int Count
	{
		get{return this.cards.Count;}
	}

	public Card Draw()
	{
		var nextCard = NextCard;
		this.cards.Remove(nextCard);
		return NextCard;
	}

	private Card NextCard //TopDeck? //This function can be used for cards like "Look at the top of your deck"
	{
		get{return this.cards[drawIndex];}
	}


	void GenerateRandomDeck()
	{
		Debug.Log($"Generating random deck...");
		for(int index=0;index<maxSize;index++)
		{
			cards.Add(Game.CardCollection.GetRandomCard());
		}
	}

	public void Shuffle()
	{

	}

}

}
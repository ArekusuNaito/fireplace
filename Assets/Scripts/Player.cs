using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  
{
	public string name;
	[Range(0,30)]
	public int health;
	[Range(30,50)]
	public int maxHealth=30;
	public HeroClass heroClass;
	public Deck deck;
	public Hand hand;

	public int mana;
	public int totalMana=0;
	public int turn=0;

	public Player(string name)
	{
		this.name = name;
		this.health = maxHealth; 
		this.hand = new Hand();
		this.deck = new Deck();

		for(int index=0;index<3;index++)
		{
			this.DrawCard();
		}
		
	}

	public void NextTurn()
	{

		this.AddMana();
		this.DrawCard();
		this.ShowHand();
		
	}

	public void TurnDescription()
	{
		// var 
	}

	public void AddMana()
	{
		if(totalMana<Game.MaxMana)
		{
			totalMana++;
			this.mana=totalMana;
		}
	}

	public void DrawCard()
	{
		var nextCard = this.deck.Draw();
		if(this.hand.IsFull)
		{
			Debug.LogError($"{this.name}'s hand is full!");
			return;
			// Add it to a Burned cards list? Like... a removed List for other mechanics? 🤔
		} 
		this.hand.Add(nextCard);
	}

	public void ShowHand()
	{
		Debug.Log($"{this.name}'s hand: {hand.Count} Deck: {deck.Count}");
		hand.Show();
	}


}

public enum HeroClass
{
	All,Paladin,Druid
}

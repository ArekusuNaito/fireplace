﻿namespace Logic
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using System;
	using UI;
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

		public PlayerBoard board;
		public UI.PlayerBoard boardUI;

		public Player(string name)
		{
			this.name = name;
			this.health = maxHealth; 
			this.hand = new Hand();
			this.deck = new Deck();
			this.board = new PlayerBoard();

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
			Debug.Log($"{this.name}'s hand: {hand.Show()}");
		}

		public void Play(string cardName)
		{
			var card = this.hand.FindCard(cardName);
			try
			{
				if(this.HasEnoughMana(card.manaCost))
				{
					if(card.IsMinion && HasSpaceInBoard)
					{
						Debug.Log($"{this.name} summons a: {card.name}");
						Minion minionSummoned = this.board.SummonMinion(card);
						this.mana-=card.manaCost; //This action is shared when you play a spell
						this.hand.Remove(card); //This action is shared when you play a spell
						//UI
						boardUI.Summon(minionSummoned);
						
					}
					else
					{
						Debug.LogWarning($"{this.name} has too many minions");
					}
				}
				else
				{
					Debug.LogWarning($"{this.name} doesn't have enough mana!");
				}

			}catch(NullReferenceException error)
			{
				Debug.LogWarning($"Well something happened: {error.StackTrace}");
				
			}
		}

		public void Attacks()
		{
			//For easy programming the mechanic FOR NOW will be
			//Strongest minion attacks the highest health enemy minion
			//If there are no minions, you go face
			if(this.HasMinions)
			{	
				var opponent = Game.Opponent;
				var myMinion = this.board.MostPowerfulMinion;
				if(opponent.HasNoMinions)
				{
					opponent.TakeDamage(myMinion.attack);
				}
				else
				{
					var opponentMinion = Game.Opponent.board.MostHealthyMinion;
					//Cross attack!
					myMinion.TakeDamage(opponentMinion.attack);
					opponentMinion.TakeDamage(myMinion.attack);					
					if(myMinion.Died)
					{
						
						this.board.Remove(myMinion);
						this.boardUI.Remove(myMinion);
						Debug.Log($"{this.name}'s {myMinion.Name} died :(");
					}
					if(opponentMinion.Died)
					{
						
						opponent.board.Remove(opponentMinion);
						opponent.boardUI.Remove(opponentMinion);
						Debug.Log($"{opponent.name}'s {opponentMinion.Name} died :(");
					}
				}
			}
			else
			{
				Debug.Log($"{this.name} doesn't have any minions!");
			}			
		}

		public void TakeDamage(int damage)
		{
			this.health-=damage;
		}
		private bool HasEnoughMana(int cardMana)
		{
			return cardMana<=this.mana;
		}

		private bool HasMinions
		{
			get{return (this.board.minions.Count>0);}
		}

		private bool HasSpaceInBoard
		{
			get{return (this.board.minions.Count<Game.BoardSize)?true:false;}
		}
		private bool HasNoMinions
		{
			get{return (this.board.minions.Count==0)?true:false;}
		}

	}

	public enum HeroClass
	{
		All,Paladin,Druid
	}
}

namespace Logic
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	//Is it neccesary to inherit from Card?
	
	public class Minion 
	{
		public int health;
		public int maxHealth;
		public int attack;
		public int maxAttack;
		public Card card;
		//A list of buffs and debuffs?
		public Minion(Card card)
		{
			this.health = card.health;
			this.maxHealth = card.health;
			this.attack = card.attack;
			this.maxAttack = card.attack;
			this.card = card;
		}
		
		public void TakeDamage(int damage)
		{
			this.health-=damage;
		}

		public bool Died
		{
			get{return this.health<=0?true:false;}
		}

		public Sprite Sprite
		{
			get{return this.card.sprite;}
		}

		public string Name
		{
			get{return this.card.name;}
		}

	}

}
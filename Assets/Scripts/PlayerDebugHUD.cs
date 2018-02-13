using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;
using Logic;

public class PlayerDebugHUD : MonoBehaviour 
{
	public Text playerName;
	public Text deckCount;
	public Text handCount;
	public Text mana;
	public Text health;

	Player player;
	public void SetPlayer(Player player)
	{
		this.player = player;

	}
	
	//This can be redone with Reactive Programming 🤔
	void UpdateValues()
	{
		this.playerName.text = this.player.name;
		this.deckCount.text = this.player.deck.Count.ToString();
		this.handCount.text = this.player.hand.Count.ToString();
		this.mana.text = $"{this.player.mana} / {this.player.totalMana}";
	}
	public void Update()
	{
		UpdateValues();
	}
}

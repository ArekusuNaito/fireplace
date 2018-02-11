using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board  
{
    public PlayerBoard player1Board;
    public PlayerBoard player2Board;

    public Board(Player player1,Player player2)
    {
        this.player1Board = player1.board;
        this.player2Board = player2.board;
    }



}

public class PlayerBoard
{
    public List<CardData> minions = new List<CardData>(7);
    private Board board;

    public void SummonMinion(CardData card)
    {
        this.minions.Add(card);
        //card.BattleCry();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour 
{
	public static Game instance;
	public Player player1,player2;
	public CardData theCoin;
	public CardCollection cardCollection;
	public TurnManager turnManager;
	[Range(0,10)]
	public int gameMaxMana=10;

	public static int MaxMana
	{
		get{return instance.gameMaxMana;}
	}

	[Space(10)]
	[Header("Debug")]
	public PlayerDebugHUD playerOneDebug;
	public PlayerDebugHUD playerTwoDebug;

	public class TurnManager
	{
		private List<Player> players = new List<Player>();
		
		public TurnManager()
		{
			// this.players.Add(one);
			// this.players.Add(two);
		}

		public void Add(Player player)
		{
			if(players.Count>=2)Debug.LogError($"Too many players in the game 🤔");
			this.players.Add(player);
		}

		public void InitialOrder(Player firstPlayer, Player secondPlayer)
		{
			players.Add(firstPlayer);
			players.Add(secondPlayer);
		}

		public void NextTurn()
		{
			var nextPlayer = this.NextPlayer;
			nextPlayer.NextTurn();
			this.players.Remove(nextPlayer); 
			this.players.Add(nextPlayer);
		}

		private Player NextPlayer
		{
			get{return this.players[0];}
		}

	}


	public static CardCollection CardCollection
	{
		get{return instance.cardCollection;}
	}
	


	void Awake()
	{
		Setup();
		this.player1 = new Player("Luigi");
		this.player2 = new Player("Alex");
		this.turnManager = new TurnManager();
		this.playerOneDebug.SetPlayer(player1);
		
		// turnManager.Add(player1);
		// turnManager.Add(player2);

		//The players already have their decks created

		//Start the match
		//Decide who goes first

		

		var coin = ThrowTheCoin();
		if(coin == 0)
		{
			AddCoinTo(player1);
			turnManager.InitialOrder(player2,player1);

		}
		else
		{
			AddCoinTo(player2);
			turnManager.InitialOrder(player1,player2);
		}






	}


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			turnManager.NextTurn();
		}
	}


	void Setup()
	{
		Game.instance = this;
	}


	void AddCoinTo(Player player)
	{
		player.hand.Add(ScriptableObject.Instantiate(theCoin));
	}

	public int ThrowTheCoin()
	{
		var coinResult = Random.Range(0,2); //Heads or tails
		Debug.Log($"{coinResult}");
		return coinResult;

	}

	

}

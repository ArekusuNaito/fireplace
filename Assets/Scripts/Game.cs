using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour 
{
	public static Game instance;
	public Player player1,player2;
	public CardData theCoin;
	public CardCollection cardCollection;
	public TurnManager turnManager;
	public Board board;
	public CommandBox commandBox;
	public CommandExecutor commandExecutor;
	[Range(0,10)]
	public int gameMaxMana=10;

	public static int MaxMana
	{
		get{return instance.gameMaxMana;}
	}

	public static Player CurrentPlayer
	{
		get{return instance.turnManager.CurrentPlayer;}
	}
	public static void EndTurn()
	{
		instance.turnManager.NextTurn();
	}

	public static Board Board
	{
		get{return instance.board;}
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
		}

		public void Add(Player player)
		{
			if(players.Count>=2)
			{
				Debug.LogError($"Too many players in the game 🤔");
				return;
			}
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

		public Player CurrentPlayer
		{
			get{return this.players[1];}
		}

		public Player NextPlayer
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
		//Game start!
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
		turnManager.NextTurn(); //Turn 1 the first player
		this.commandBox.RecoverFocus();
	}


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			// turnManager.NextTurn();
		}
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			player1.ShowHand();
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			player2.ShowHand();
		}
	}


	void Setup()
	{
		Game.instance = this;
		//
		this.commandExecutor = new CommandExecutor();
		this.commandBox.executor = this.commandExecutor; //Add the executor to the commandBox
		this.player1 = new Player("Luigi");
		this.player2 = new Player("Alex");
		this.turnManager = new TurnManager();
		this.board = new Board(player1,player2);
		this.playerOneDebug.SetPlayer(player1);
		this.playerTwoDebug.SetPlayer(player2);
	}


	void AddCoinTo(Player player)
	{
		player.hand.Add(ScriptableObject.Instantiate(theCoin));
	}

	public int ThrowTheCoin()
	{
		var coinResult = Random.Range(0,2); //Heads or tails
		return coinResult;

	}

	

}

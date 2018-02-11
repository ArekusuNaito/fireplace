using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

// Artanis: Yes, Executor!
public class CommandExecutor  
{
	Dictionary<string,Action<string>> commands;

	
	public CommandExecutor()
	{
		commands= new Dictionary<string,Action<string>>()
		{
			["hand"] = this.ShowHand,
			["end"] = this.EndTurn,
			["play"] = this.PlayCard,
		};
	}
	public void Process(string command)
	{
		//This is the function that I would love to improve quickly

		//Check for two word commands
		if(Regex.IsMatch(command,@"(\w+) \b(.+)"))
		{
			var match = Regex.Match(command,@"(\w+) \b(.+)");
			//Remember Groups[0] returns the whole string
			var action = match.Groups[1].Value;
			var parameter = match.Groups[2].Value;
			action = action.ToLower();
			parameter = parameter.ToLower();
			if(this.commands.ContainsKey(action))
			{
				var executeCommand = this.commands[action];
				Debug.Log("Executing"+executeCommand);	
				executeCommand(parameter);
			}
		}
		else if(Regex.IsMatch(command,@"(\w+)")) //Check for one word commands
		{
			var match = Regex.Match(command,@"(\w+)");
			var action = match.Groups[1].Value;
			action = action.ToLower();
			if(this.commands.ContainsKey(action))
			{
				var executeCommand = this.commands[action];
				Debug.Log("Executing"+executeCommand);	
				executeCommand(null);
			}
		}
	}	

	public void ShowHand(string parameter=null)
	{
		Game.CurrentPlayer.ShowHand();
	}

	public void EndTurn(string parameter=null)
	{
		Game.EndTurn();
	}
	public void PlayCard(string cardName)
	{

		Game.CurrentPlayer.Play(cardName);
	}
}

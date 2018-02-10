using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

// Artanis: Yes, Executor!
public class CommandExecutor  
{
	Dictionary<string,Action> commands;

	
	public CommandExecutor()
	{
		commands= new Dictionary<string,Action>()
		{
			["show hand"] = this.ShowHand,
		};
	}
	public void Process(string command)
	{
		if(Regex.IsMatch(command,@"(\w{1,}) \b(.{1,})"))
		{
			var match = Regex.Match(command,@"(\w{1,}) \b(.{1,})");
			//Remember Groups[0] returns the whole string
			var action = match.Groups[1].Value;
			var parameter = match.Groups[2].Value;
			action = action.ToLower();
			parameter = parameter.ToLower();
			// Debug.Log($"Action: {action} parameter: {parameter}");
			if(this.commands.ContainsKey($"{action} {parameter}"))
			{
				var executeCommand = this.commands[$"{action} {parameter}"];
				executeCommand();
			}
		}
	}	

	public void ShowHand()
	{
		Game.CurrentPlayer.ShowHand();
	}
}

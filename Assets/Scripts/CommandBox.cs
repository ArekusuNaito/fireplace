using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CommandBox : MonoBehaviour 
{
	public InputField inputField;

	void Start()
	{
		this.inputField.onEndEdit.AddListener((inputField)=>
		{
			if(Input.GetKeyDown(KeyCode.Return))
			{
				var command = this.inputField.text;
				// Debug.Log($"Acaso escribiste.... {command} 😲?");
				this.Clear();
				this.Process(command);
			}
		});
	}

	void Process(string command)
	{
		switch(command.ToLower())
		{
			case "hand":
			{
				ShowHand();
				break;
			}
			case "play":
			{
				PlayCard(command);
				break;	
			}
		}
	}

	//Commands
	public void ShowHand()
	{
		Game.CurrentPlayer.ShowHand();
	}

	public void PlayCard()
	{
		
	}
	//

	void Clear()
	{
		this.inputField.text  = "";
	}

	void Update()
	{
		// if(Input.GetKeyDown(KeyCode.Return))
		// {
		// 	if(this.inputField.isFocused)
		// 	{
		// 		this.command = this.inputField.text;
		// 		Debug.Log($"Acaso escribiste.... {this.command} 😲?");
		// 	}
		// }
	}
	
}

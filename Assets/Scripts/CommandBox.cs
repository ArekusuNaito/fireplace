using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandBox : MonoBehaviour 
{
	public InputField inputField;
	public CommandExecutor executor; //This guy separates UI from Logic

	void Start()
	{
		this.inputField.onEndEdit.AddListener((inputField)=>
		{
			if(Input.GetKeyDown(KeyCode.Return))
			{
				var command = this.inputField.text;
				this.Clear();
				this.RecoverFocus();
				executor.Process(command);
			}
		});
	}

	public void RecoverFocus()
	{
		this.inputField.ActivateInputField();
	}

	void Clear()
	{
		this.inputField.text  = "";
	}
	
}

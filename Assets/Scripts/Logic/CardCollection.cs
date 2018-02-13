namespace Logic
{
	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card Collection", menuName = "Card/New Collection", order = 1)]
public class CardCollection : ScriptableObject 
{
	public List<Card> collection;

	public Card GetRandomCard()
	{
		var card = ScriptableObject.Instantiate(collection[RandomCardIndex]); //Instantiate will create a clon, this way the object won't be modified in editor runtime
		// Debug.Log($"Generated Card: {card.name}");
		return 	card;
	}

	private int RandomCardIndex
	{
		get{return Random.Range(0,collection.Count);}
	}


}

}
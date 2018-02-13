namespace UI
{
	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Logic;

public class Board : MonoBehaviour 
{	
	
	public List<Minion> minions = new List<Minion>();
	private RectTransform rectTransform;
	private float Width
	{
		get{return this.rectTransform.rect.width;}
	}
	private float Height
	{
		get{return this.rectTransform.rect.width;}
	}
	private Vector2 Min
	{
		get{return this.rectTransform.rect.min;}
	}
	private Vector2 Max
	{
		get{return this.rectTransform.rect.max;}
	}

	public void Awake()
	{
		this.rectTransform = GetComponent<RectTransform>();
	}

	
	public void Summon(Card card)
	{

		var minionOriginal = Resources.Load<Minion>("Minion");
		
		var minion = Instantiate(minionOriginal,this.transform,false);
		
		minion.SetLocalPosition(new Vector2(this.rectTransform.rect.center.x, this.Max.y-(minion.Height*minions.Count)));
		minion.SetData(card.sprite,card.attack,card.health);
		minions.Add(minionOriginal);
	}

}

}
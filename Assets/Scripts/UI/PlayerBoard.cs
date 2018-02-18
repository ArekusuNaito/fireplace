namespace UI
{
	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Logic;

public class PlayerBoard : MonoBehaviour 
{	
	public Logic.PlayerBoard data;
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

	
	public void Summon(Logic.Minion minionData)
	{
		var minionPrefab = Resources.Load<Minion>("Minion");
		var minion = Instantiate(minionPrefab,this.transform,false);
		minion.SetLocalPosition(new Vector2(this.rectTransform.rect.center.x, this.Max.y-(minion.Height*minions.Count)));
		minion.SetData(minionData);
		minions.Add(minion);
	}

	public void Remove(Logic.Minion minionData)
	{
		var minion = FindMinion(minionData);
		Debug.Log($"UI Board is Removing: {minion.data.Name} {minion.data.health}");
		this.minions.Remove(minion);
		Destroy(minion.gameObject);
		//Reposition minions?
	}

	public Minion FindMinion(Logic.Minion minionData)
	{
		return this.minions.Find(queryMinion=> minionData==queryMinion.data);
		
	}
}

}
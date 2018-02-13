namespace UI
{
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion : MonoBehaviour 
{
	public Image image;
    public Text attack;
    public Text health;
    private RectTransform rectTransform;

    public float Width
    {
        get{return this.rectTransform.rect.width;}
    }
    public float Height
    {
        get{return this.rectTransform.rect.height;}
    }

    public void Awake()
    {
        this.rectTransform = GetComponent<RectTransform>();
        
    }

    public void SetLocalPosition(Vector2 newPosition)
    {
        this.rectTransform.localPosition = newPosition;
    }

    public void SetData(Sprite sprite,int attack, int health)
    {
        this.image.sprite = sprite;
        this.attack.text = attack.ToString();
        this.health.text = health.ToString();
    }

}

}
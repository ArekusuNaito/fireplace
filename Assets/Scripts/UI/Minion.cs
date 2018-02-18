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
    public Logic.Minion data;

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

    public void SetData(Logic.Minion data)
    {
        this.data = data;
        this.image.sprite = data.Sprite;
    }


}

}
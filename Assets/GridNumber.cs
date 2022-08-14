using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridNumber : MonoBehaviour
{
    [SerializeField] TextMeshPro numberText;
    [SerializeField] SpriteRenderer sprite;
    public int Number {get; private set;}

    public void HighlighNumber(Color color)
    {
        numberText.color = color;
    }

    public void HighlightGrid(Color color)
    {
        sprite.color = color;
    }
    void OnMouseDown()
    {
        string n = GameManager.SelectedNumber == 0 ? "" : GameManager.SelectedNumber.ToString();
        numberText.text = n;
        Number = GameManager.SelectedNumber;
        
        GameManager.instance.FindRows(this);
    }
}

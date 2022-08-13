using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridNumber : MonoBehaviour
{
    [SerializeField] TextMeshPro numberText;
    [SerializeField] SpriteRenderer sprite;
    public int Number {get; private set;}

    public void SelectGrid()
    {
        sprite.color = Color.green;
    }
    
    public void DeselectGrid()
    {
        sprite.color = Color.white;
    }

    void OnMouseDown()
    {
        string n = GameManager.SelectedNumber == 0 ? "" : GameManager.SelectedNumber.ToString();
        numberText.text = n;
        Number = GameManager.SelectedNumber;
        
        GameManager.instance.FindRows(this);
    }
}

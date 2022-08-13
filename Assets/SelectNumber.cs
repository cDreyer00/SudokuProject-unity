using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectNumber : MonoBehaviour
{
    public int MyNumber { get; private set; }
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TextMeshPro numberText;

    public void Initialize(int number)
    {

        MyNumber = number;
        numberText.text = MyNumber.ToString();
        Selected();
    }

    public void Selected()
    {
        sprite.color = GameManager.SelectedNumber == MyNumber ? Color.green : Color.grey;
    }

    void OnMouseDown()
    {
        GameManager.SetNumber(MyNumber);
        GameManager.instance.CheckSelected();
    }
}

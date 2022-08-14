using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject gridSquare;
    [SerializeField] SelectNumber[] selectNumbers;

    public static int SelectedNumber { get; private set; }

    List<GridNumber> gridNumbers = new();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Grid grid = new Grid(9, 9, 1);
        CreateGrid(grid.width, grid.height, grid.size);

        for (int i = 0; i < selectNumbers.Length; i++)
        {
            selectNumbers[i].Initialize(i + 1);
        }
    }

    void CreateGrid(int x, int y, int size)
    {
        for (int i = 0; i < y; i++)
        {
            for (int k = 0; k < x; k++)
            {
                GridNumber gn = Instantiate(gridSquare, Vector3.zero + Vector3.right * k + Vector3.up * i, Quaternion.identity).GetComponent<GridNumber>();
                gridNumbers.Add(gn);
            }
        }
    }

    public static void SetNumber(int value)
    {
        SelectedNumber = SelectedNumber == value ? 0 : value;
    }

    public void CheckSelected()
    {
        foreach (var n in selectNumbers) n.Selected();
    }

    void HighlightRows(List<GridNumber> gridRows)
    {
        foreach (GridNumber g in gridNumbers) g.DeselectGrid();
        foreach (GridNumber g in gridRows) g.SelectGrid();
    }

    void CheckSameNumbers(int column, int line)
    {
        List<GridNumber> rowNumbers = new();

        // verify same column grid and add to list
        for(int i= 0; i < gridNumbers.Count; i++){
            if(i % 9 == column - 1){
                rowNumbers.Add(gridNumbers[i]);
            }
        }

        // catch repetitive numbers and mark
        for(int i = 0; i < rowNumbers.Count; i++ ){
            for(int k = 0; k < rowNumbers.Count; i ++){
                if(rowNumbers[i].Number == rowNumbers[k].Number){
                    rowNumbers[i].HiglighNumber(Color.red);
                    rowNumbers[k].HiglighNumber(Color.red);
                }
            }
        }

        // clear list

        // do same to the line
         
    }

    public void FindRows(GridNumber grid)
    {
        int column = 1;
        int line = 1;
        int gridIndex = gridNumbers.IndexOf(grid);


        for (int i = 0; i < gridNumbers.Count; i++)
        {
            if (gridIndex % 9 == column - 1) break;
            column++;
        }

        for (int i = 0; i < gridNumbers.Count; i++)
        {
            if (i + 1 > 9 * line) line++;
            if (i == gridIndex) break;
        }

        List<GridNumber> SelectedGrids = GetSameRowGrids(column, line);
        HighlightRows(SelectedGrids);
        CheckSameNumbers(column, line);
    }


    List<GridNumber> GetSameRowGrids(int column, int line)
    {
        int minLineVal = line * 9 - 9;
        int maxLineVal = line * 9;
        List<GridNumber> gn = new();

        for (int i = 0; i < gridNumbers.Count; i++)
        {

            if (i % 9 == column - 1)
            {
                gn.Add(gridNumbers[i]);
            }
            else if (i >= minLineVal && i < maxLineVal)
            {
                gn.Add(gridNumbers[i]);
            }

        }

        return gn;
    }


    int Count(int i)
    {
        if (i == 1) return 1;
        return Count(i - 1) + 1;
    }

}

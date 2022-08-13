using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public readonly int width;
    public readonly int height;
    public readonly int size;

    public Grid(int width, int height, int size)
    {
        this.width = width;
        this.height = height;
        this.size = size;
    }
}

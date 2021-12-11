using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayField : MonoBehaviour
{
    public static int width = 10;
    public static int height = 20;
    public GameObject outline;

    public static Transform[,] grid = new Transform[width, height];

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Instantiate(outline, new Vector2(x * 1, y * 1), Quaternion.identity);
            }
        }
    }

    public static Vector2 roundVec2(Vector2 v) // this rounds the vector to whole numbers
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool InsideBorder(Vector2 pos)
    {
        return (int)pos.x >= 0 && (int)pos.x < width && (int)pos.y > 0;
    }

    public static void deleteRow(int y)
    {
        for (int i = 0; i < width; i++)
        {
            Destroy(grid[i, y].gameObject);
            grid[i, y] = null;
        }
    }

    public static void descreaseRow(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if(grid[x, y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0); // moving the blocks down
            }
        }
        TetrisHUD.GameScore++; // updating score
    }

    public static void decreaseRowsAbove(int y)
    {
        for (int i = 0; i < height; i++)
        {
            descreaseRow(i);
        }
    }

    public static bool isRowFull(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public static void deleteFullRows()
    {
        for (int y = 0; y < height; y++)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                decreaseRowsAbove(y + 1);
                --y;
            }
        }
    }

}

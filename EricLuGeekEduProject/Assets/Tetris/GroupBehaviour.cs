using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// some notes, the group's transform is the parent empty game object and the child transforms are the individual squares

public class GroupBehaviour : MonoBehaviour
{
    float lastFall;

    // Start is called before the first frame update
    void Start()
    {
        if (!isValidGridPos())
        {
            print("GAME OVER"); // we'll add this to switch back to the start menu
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // all of our input to move the blocks
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                PlayField.deleteFullRows();

                FindObjectOfType<BlockSpawner>().spawnNext();
                enabled = false; // when we do this it stops the script from working on this object
            }
            lastFall = Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                transform.Rotate(0, 0, 90);
            }
        }
    }

    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = PlayField.roundVec2(child.position);

            if (!PlayField.InsideBorder(v)) // not inside the border
            {
                return false;
            }

            if(PlayField.grid[(int)v.x, (int)v.y] != null && PlayField.grid[(int)v.x, (int)v.y].parent != transform) // blocked in the grid cell
            {
                return false;
            }
        }
        return true;
    }

    void updateGrid()
    {
        // removing the blocks
        for (int y = 0; y < PlayField.height; y++)
        {
            for (int x = 0; x < PlayField.width; x++)
            {
                if(PlayField.grid[x, y] != null)
                {
                    if(PlayField.grid[x,y].parent == transform)
                    {
                        PlayField.grid[x, y] = null;
                    }
                }
            }
        }
        // putting in the new blocks to the lower row
        foreach (Transform child in transform)
        {
            Vector2 v = PlayField.roundVec2(child.position);
            PlayField.grid[(int)v.x, (int)v.y] = child;
        }
    }
}

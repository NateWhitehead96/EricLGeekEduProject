using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// some notes, the group's transform is the parent empty game object and the child transforms are the individual squares

public class GroupBehaviour : MonoBehaviour
{
    float lastFall;
    public float DropTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (!isValidGridPos())
        {
            print("GAME OVER"); // we'll add this to switch back to the start menu
            SceneManager.LoadScene("MainMenu");
            Destroy(gameObject);
        }
        FindObjectOfType<BlockSpawner>().FindNextBlock();
        //FindObjectOfType<DisplayNextBlock>().UpdateNext();
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
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= DropTime)
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
        else if (Input.GetKeyDown(KeyCode.Space)) // when we switch, we store that value in a held block and delete the current block + spawn a new one
        {
            FindObjectOfType<HeldBlock>().SwitchBlock(FindObjectOfType<BlockSpawner>().previous);
            Destroy(gameObject);
        }

        if(TetrisHUD.GameScore >= TetrisHUD.OldScore + 100)
        {
            TetrisHUD.OldScore += 100;
            DropTime -= 0.2f;
            if(DropTime < 0.2f)
            {
                DropTime = 0.2f; // this makes sure we never drop blocks faster than 0.2 seconds
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

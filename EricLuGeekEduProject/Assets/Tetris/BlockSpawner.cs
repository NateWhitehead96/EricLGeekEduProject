using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] groups;
    public int next;
    // Start is called before the first frame update
    void Start()
    {
        FindNextBlock();
        spawnNext();
    }

    public void spawnNext()
    {
        //int i = Random.Range(0, groups.Length);

        //Instantiate(groups[i], transform.position, Quaternion.identity);
        Instantiate(groups[next], transform.position, Quaternion.identity);
    }

    public int FindNextBlock()
    {
        //FindObjectOfType<DisplayNextBlock>().UpdateNext();
        next = Random.Range(0, groups.Length);
        return next;
        //NextBlock = Instantiate(groups[i], transform.position, Quaternion.identity);
    }
}

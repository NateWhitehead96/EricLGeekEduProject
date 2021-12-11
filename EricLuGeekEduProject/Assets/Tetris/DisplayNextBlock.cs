using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNextBlock : MonoBehaviour
{
    public GameObject[] NextBlock;
    public BlockSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NextBlock.Length; i++)
        {
            NextBlock[i].SetActive(false);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //NextBlock = Instantiate(spawner.NextBlock, transform.position, Quaternion.identity);
        for (int i = 0; i < NextBlock.Length; i++)
        {
            if (spawner.next == i)
            {
                NextBlock[i].SetActive(true);
            }
            else
                NextBlock[i].SetActive(false);
        }
    }

    public void UpdateNext()
    {
        for (int i = 0; i < NextBlock.Length; i++)
        {
            NextBlock[i].SetActive(false);
            if (spawner.FindNextBlock() == i)
            {
                NextBlock[i].SetActive(true);
            }
        }
    }
}

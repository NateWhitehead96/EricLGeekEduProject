using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldBlock : MonoBehaviour
{
    public GameObject[] HeldBlocks;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < HeldBlocks.Length; i++)
        {
            HeldBlocks[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchBlock(int i)
    {
        for (int x = 0; x < HeldBlocks.Length; x++)
        {
            if(i == x)
            {
                //if (HeldBlocks[x].activeInHierarchy)
                //{

                //}
                HeldBlocks[x].SetActive(true);
                FindObjectOfType<BlockSpawner>().spawnNext();
            }
            else
            {
                HeldBlocks[x].SetActive(false);
            }
        }
    }
}

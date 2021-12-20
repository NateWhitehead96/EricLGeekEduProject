using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessCheckpoint : MonoBehaviour
{
    public GameObject[] Sections;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int i = Random.Range(0, Sections.Length);
            SectionManager.Sections.Add(Instantiate(Sections[i], new Vector3(transform.parent.position.x + 100, transform.parent.position.y), Quaternion.identity));
        }
    }
}

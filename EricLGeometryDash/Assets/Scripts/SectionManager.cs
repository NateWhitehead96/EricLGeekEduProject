using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    public static List<GameObject> Sections;
    // Start is called before the first frame update
    void Start()
    {
        Sections = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Sections.Count > 4)
        {
            Destroy(Sections[0]);
            Sections.RemoveAt(0);
        }
    }
}

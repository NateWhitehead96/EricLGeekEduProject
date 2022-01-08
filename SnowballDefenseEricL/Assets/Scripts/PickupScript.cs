using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    IncreaseShootSpeed,
    IncreaseSnowballSize,
    AddHealth
}

public class PickupScript : MonoBehaviour
{
    public Type type;
    public int moveSpeed;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        int x = Random.Range(0, 3);
        if(x == 0)
        {
            type = Type.IncreaseShootSpeed;
            sprite.color = Color.blue;
        }
        if(x == 1)
        {
            type = Type.IncreaseSnowballSize;
            sprite.color = Color.cyan;
        }
        if(x == 2)
        {
            type = Type.AddHealth;
            sprite.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);

        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}

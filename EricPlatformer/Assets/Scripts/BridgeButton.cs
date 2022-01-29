using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public GameObject[] bridgePlanks;
    public Sprite pressedImage;
    public SpriteRenderer sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(OpenBridge());
        }
    }

    IEnumerator OpenBridge()
    {
        sprite.sprite = pressedImage; // change the image to be pressed
        for (int i = 0; i < bridgePlanks.Length; i++) // set one plank active every 1 second
        {
            bridgePlanks[i].SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moveSpeed; // how fast it goes
    private Animator animator;

    public GameObject HitEffect; // a reference to the hit effect particle system
    public GameObject Effect;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);

        if(transform.position.x < -12)
        {
            ScoringSystem.Lives--;
            CameraShake.shakeDuration = 1;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            health--;
            Destroy(collision.gameObject); // first destroy the snowball
            if (health <= 0)
            {
                ScoringSystem.Score += 5;
                Effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
                StartCoroutine(DyingAnimation());
            }
        }
    }

    IEnumerator DyingAnimation()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false; // disable collider so other enemies can pass
        animator.SetBool("Dying", true); // plays the dying animation
        moveSpeed = 0;
        yield return new WaitForSeconds(3);
        Destroy(Effect); // destroy the particle effect
        Destroy(gameObject); // destroy self
    }
}

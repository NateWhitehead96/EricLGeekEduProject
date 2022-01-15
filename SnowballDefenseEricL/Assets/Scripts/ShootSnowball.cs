using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSnowball : MonoBehaviour
{
    public GameObject ball;

    public GameObject PauseCanvas;

    public bool shooting; // this bool will know if we're shooting or not

    public float shootSpeed;

    public float snowballSize;
    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.SetActive(false); // hide the pause menu by defualt
    }

    // Update is called once per frame
    void Update()
    {
        // have player look at mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(mousePosition);

        if (Input.GetMouseButtonDown(0) && PauseCanvas.activeInHierarchy == false && shooting == false) // left click input
        {
            StartCoroutine(FireSnowball());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseCanvas.activeInHierarchy) // if the pause menu is on the screen
            {
                Time.timeScale = 1;
                PauseCanvas.SetActive(false);
            }
            else // the pause menu isnt on the screen
            {
                Time.timeScale = 0;
                PauseCanvas.SetActive(true);
            }
        }
    }

    IEnumerator FireSnowball()
    {
        shooting = true;
        GameObject newSnowball = Instantiate(ball, transform.position, Quaternion.identity); // spawing the ball of snow
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // mouse position
        Vector3 shootDirection = mousePosition - transform.position; // the new direction vector between our mouse and player
        newSnowball.GetComponent<Snowball>().size = snowballSize;
        newSnowball.GetComponent<Snowball>().MoveToPosition = new Vector3(shootDirection.x, shootDirection.y); // applying that direction vector to our snowball
        yield return new WaitForSeconds(shootSpeed); // a cooldown for shooting snowball
        shooting = false;
    }
}

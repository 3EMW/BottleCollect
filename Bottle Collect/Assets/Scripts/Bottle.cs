using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bottle : MonoBehaviour
{
    public Transform bottleTwo;
    public TextMeshProUGUI healthText, endText;
    public int health;
    public AudioSource breaking;

    private void Update()
    {
        healthText.text = "" + health;
        if (health == 0)
        {
            endText.text = "Game the End \n Press the button to replay the game";
            Time.timeScale = 0;

            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D contact2)
    {
        float random = Random.Range(-2f, 2f);
        if (contact2.gameObject.tag == "Ground")
        {
            bottleTwo.position = new Vector3(random, 6f, 0f);
            health--;
            breaking.Play();
        }
    }
}

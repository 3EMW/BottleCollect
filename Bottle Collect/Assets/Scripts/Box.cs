using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TMPro;

public class Box : MonoBehaviour
{

    public float Speed;
    public Transform bottle;
    private int point;
    public TextMeshProUGUI pointText;
    public AudioSource taking;

    void Update()
    {
        pointText.text = " " + point;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-Speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Speed * Time.deltaTime, 0f, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D contact)
    {
        float random = Random.Range(-2f, 2f);
        if (contact.gameObject.tag == "Bottle")
        {
            bottle.position = new Vector3(random, 6f, 0f);
            point += 5;
            taking.Play();
        }
    }
}

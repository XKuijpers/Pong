using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using TMPro;
using static Unity.VisualScripting.Member;

public class atariBall : MonoBehaviour
{
    public float xPosition = 0f;
    public float yPosition = 0f;
    public float xSpeed = -4f;
    public float ySpeed = 4f;
    public TMP_Text scoreText;
    public int yourScore = 0;
    public int winScore = 90;
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(xPosition, yPosition, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        xPosition = xPosition + xSpeed * Time.deltaTime;
        yPosition = yPosition + ySpeed * Time.deltaTime;
        transform.position = new Vector3(xPosition, yPosition, 0f);
        if (yourScore >= winScore)
        {
            scoreText.text = "You've won the game!";
            xPosition = 0f;
            yPosition = 0f;
        }
        else if (scoreText.text == "You've lost the game!")
        {
            xPosition = 0f;
            yPosition = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("horizontalWall"))
        {
            ySpeed = ySpeed * -1f;
        }
        else if (collision.gameObject.CompareTag("atariBrick"))
        {
            source.PlayOneShot(clip);
            xSpeed = xSpeed * -1f;
            yourScore = yourScore + 5;
            scoreText.text = yourScore + "/90";
        }
        else if (collision.gameObject.CompareTag("verticalL"))
        {
            source.PlayOneShot(clip);
            scoreText.text = "You've lost the game!";
        }
        else if (collision.gameObject.CompareTag("verticalR"))
        {
            source.PlayOneShot(clip);
            xSpeed = xSpeed * -1f;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(clip);
            xSpeed = xSpeed * -1.1f;
        }
    }
}


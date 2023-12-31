using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using TMPro;

public class collision : MonoBehaviour
{
    public float xPosition = 0f;
    public float yPosition = 0f;
    public float xSpeed = 4f;
    public float ySpeed = 4f;
    public TMP_Text scoreText;
    public int leftScore = 0;
    public int rightScore = 0;
    public int winScore = 10;
    public AudioSource source;
    public AudioClip clip;
    void resetBall()
    {
        xPosition = 0f;
        yPosition = Random.Range(-4f, 4f);
        xSpeed = 4f;
        ySpeed = 4f;
    }

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
        if (leftScore >= winScore)
        {
            scoreText.text = "Left player has won!";
            xPosition = 0f;
            yPosition = 0f;
            xSpeed = 0f;
            ySpeed = 0f;    
        }
        else if (rightScore >= winScore)
        {
            scoreText.text = "Right player has won!";
            xPosition = 0f;
            yPosition = 0f;
            xSpeed = 0f;
            ySpeed = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("horizontalWall"))
        {
            ySpeed = ySpeed * -1f;
        }
        else if (collision.gameObject.CompareTag("verticalL"))
        {
            source.PlayOneShot(clip);
            resetBall();
            rightScore++;
            scoreText.text = leftScore + " | " + rightScore;
        }
        else if (collision.gameObject.CompareTag("verticalR"))
        {
            source.PlayOneShot(clip);
            resetBall();
            leftScore++;
            scoreText.text = leftScore + " | " + rightScore;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(clip);
            xSpeed = xSpeed * -1.1f;
        }
    }
}

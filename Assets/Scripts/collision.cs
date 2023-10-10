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
    public float xSpeed = 2f;
    public float ySpeed = 2f;
    public TMP_Text scoreText;
    public int leftScore = 0;
    public int rightScore = 0;
    void resetBall()
    {
        xPosition = 0f;
        yPosition = 0f;
        xSpeed = xSpeed * -1f;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("horizontalWall"))
        {
            ySpeed = ySpeed * -1f;
        }
        else if (collision.gameObject.CompareTag("verticalL"))
        {
            resetBall();
            rightScore++;
            scoreText.text = leftScore + " | " + rightScore;
        }
        else if (collision.gameObject.CompareTag("verticalR"))
        {
            resetBall();
            leftScore++;
            scoreText.text = leftScore + " | " + rightScore;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            xSpeed = xSpeed * -1.1f;
        }
    }
}

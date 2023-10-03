using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public float xPosition = -2f;
    public float yPosition = -2f;
    public float xSpeed = 1f;
    public float ySpeed = 1f;

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
        Debug.Log("Auw!");
        if (collision.gameObject.CompareTag("horizontalWall"))
        {
            Debug.Log("my head or my feet");
            ySpeed = ySpeed * -1f;
        }
        else if (collision.gameObject.CompareTag("verticalWall"))
        {
            Debug.Log("my butt or my crotch");
            xSpeed = xSpeed * -1f;
        }
    }

}

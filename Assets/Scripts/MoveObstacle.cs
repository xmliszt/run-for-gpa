using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    private float movingSpeed = 15;
    private float destroyBound = -2;
    private float scoreBound = 1;
    private bool counted = false;
    // Update is called once per frame
    void Update()
    {
        int currentScore = FindObjectOfType<ScoreManager>().GetScore();
        movingSpeed += currentScore * 0.00001f;

        if (!FindObjectOfType<PlayerController>().gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * movingSpeed);
            
        }
        if (transform.position.y < destroyBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (!counted && gameObject.CompareTag("Obstacle") && transform.position.x - FindObjectOfType<PlayerController>().gameObject.transform.position.x < -scoreBound)
        {
            FindObjectOfType<ScoreManager>().AddScore(1);
            counted = true;
        }
    }
}

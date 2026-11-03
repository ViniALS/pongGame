using System.Numerics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{


    public Rigidbody2D rb;
    public float startingSpeed = 5;
    public float maxInitRange = 0.67f;
    public float startX = 0f;
    public float startY = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*bool isRight = UnityEngine.Random.value >= 0.5;
        float xVelocity = -1f;

        if (isRight)
        {
            xVelocity = 1f;
        }

        float yVelocity = UnityEngine.Random.Range(-1,1);
        catchX =xVelocity;
        catchY = yVelocity;

        rb.linearVelocity = new UnityEngine.Vector2(startingSpeed*xVelocity,startingSpeed*yVelocity);*/
        InitialPush();
    }



    private void InitialPush()
    {
         UnityEngine.Vector2 dir = UnityEngine.Vector2.left;

         if(Random.value < 0.5f)
        {
            dir = UnityEngine.Vector2.right;
        }
         dir.y = Random.Range(-maxInitRange, maxInitRange);
         rb.linearVelocity = dir * startingSpeed;
    }
    private void ResetBall()
    {
        UnityEngine.Vector2 position = new UnityEngine.Vector2(startX, Random.Range(-maxInitRange,maxInitRange));
        transform.position = position;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();

        if(scoreZone != null)
        {
            ResetBall();
            InitialPush();
        }
        Debug.Log("bateeeu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

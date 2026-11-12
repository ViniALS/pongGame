using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb;
    public float startingSpeed = 5;
    public float maxInitRange = 0.67f;
    public float startX = 0f;
    public float startY = 0f;
    public float bounceAngleMultiplier = 2f; 

    public float speedIncrease = 0.8f; // Quanto a velocidade aumenta a cada rebatida
    public float maxSpeed = 20f;
    private Vector3 originalScale;
    private Coroutine sizeCoroutine;
    public bool isPowerUpActive = false; 

   
    public bool isExtraBall = false;

    void Start()
    {
        originalScale = transform.localScale;
        
        
        if (!isExtraBall)
        {
            InitialPush(); 
        }
    }

    private void InitialPush()
    {
         Vector2 dir = Vector2.left;
         if(Random.value < 0.5f) dir = Vector2.right;
         
         dir.y = Random.Range(-maxInitRange, maxInitRange);
         rb.linearVelocity = dir * startingSpeed;
    }

    private void ResetBall()
    {
        Vector2 position = new Vector2(startX, Random.Range(-maxInitRange, maxInitRange));
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();

        if(scoreZone)
        {
            gameManager.OnScoreZoneReached(scoreZone.id); 
            
           if (isExtraBall)
            {
                Destroy(gameObject);
            }
            else
            {
                ResetBall();
                InitialPush();
            }
        }
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float ballY = transform.position.y;
            float paddleCenterY = collision.collider.bounds.center.y;
            float paddleHeight = collision.collider.bounds.size.y;

            float yOffset = (ballY - paddleCenterY) / paddleHeight;
            float xDirection = (transform.position.x < collision.transform.position.x) ? -1f : 1f;

            Vector2 newDirection = new Vector2(xDirection, yOffset * bounceAngleMultiplier).normalized;

           
            float currentSpeed = rb.linearVelocity.magnitude;
            
        
            currentSpeed += speedIncrease;

           
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

            
            rb.linearVelocity = newDirection * currentSpeed;
        }
    }

    public void ActivateSizePowerUp(float sizeMultiplier, float duration)
    {
        if (sizeCoroutine != null) StopCoroutine(sizeCoroutine);
        sizeCoroutine = StartCoroutine(SizeRoutine(sizeMultiplier, duration));
    }

    private IEnumerator SizeRoutine(float multiplier, float duration)
    {
        isPowerUpActive = true; 
        transform.localScale = originalScale * multiplier;
        yield return new WaitForSeconds(duration);
        transform.localScale = originalScale;
        isPowerUpActive = false; 
    }


  public void ActivateDuplicatePowerUp(float duration)
    {
        isPowerUpActive = true;
        StartCoroutine(DuplicateCooldown(duration));

        GameObject extraBall = Instantiate(gameObject, transform.position, transform.rotation);
        Ball extraBallScript = extraBall.GetComponent<Ball>();
        
        extraBallScript.isExtraBall = true;
        
        Vector2 currentVelocity = rb.linearVelocity;
        currentVelocity.y += Random.Range(-3f, 3f);
        
     float currentSpeed = rb.linearVelocity.magnitude;
        extraBallScript.rb.linearVelocity = currentVelocity.normalized * currentSpeed;
        
        Destroy(extraBall, duration);
    }

    private IEnumerator DuplicateCooldown(float duration)
    {
       
        yield return new WaitForSeconds(duration);
        isPowerUpActive = false;
    }
}
/*using UnityEngine;

public class P2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speedP2 = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         bool isWPressed = Input.GetKey(KeyCode.UpArrow);
        bool isSPressed = Input.GetKey(KeyCode.DownArrow);

        if (isWPressed)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speedP2);
        }

        if (isSPressed)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speedP2);
        }
    }
}*/
using UnityEngine;

public class P2 : MonoBehaviour
{
    public float speed = 6f; // Velocidade da IA.
    public bool isRightPaddle = true; 

    void Update()
    {
  
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        
        GameObject targetBall = null;
        float closestDistance = Mathf.Infinity;

        // 2. Analisa qual bola é a maior ameaça
        foreach (GameObject ball in balls)
        {
            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
            
            if (ballRb != null)
            {
                
                bool isMovingTowardsAI = isRightPaddle ? ballRb.linearVelocity.x > 0 : ballRb.linearVelocity.x < 0;

                if (isMovingTowardsAI)
                {
                    // Se tiver mais de uma bola vindo, foca na que estiver mais perto
                    float distance = Vector2.Distance(transform.position, ball.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        targetBall = ball;
                    }
                }
            }
        }


        float targetY = 0f;
        
        if (targetBall != null)
        {
            targetY = targetBall.transform.position.y;
        }

   
        Vector2 targetPosition = new Vector2(transform.position.x, targetY);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}

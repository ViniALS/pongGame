using UnityEngine;

public class PowerUpDuplicate : MonoBehaviour
{
    public float duration = 10f;  // Tempo que a bola extra vai viver

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Ball ballScript = collision.GetComponent<Ball>();
            
            // Só deixa ativar se o script existir e NÃO for a bola extra
            if (ballScript != null && !ballScript.isExtraBall)
            {
                ballScript.ActivateDuplicatePowerUp(duration);
                Destroy(gameObject);
            }
        }
    }
}
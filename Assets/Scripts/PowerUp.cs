using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 10f; // O dobro do tamanho
    public float duration = 10f;  // 10 segundos de duração

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se quem bateu foi a bola
        if (collision.CompareTag("Ball"))
        {
            Ball ballScript = collision.GetComponent<Ball>();
            if (ballScript != null)
            {
                // Ativa o poder e destrói o quadrado rosa
                ballScript.ActivateSizePowerUp(multiplier, duration);
                Destroy(gameObject);
            }
        }
    }
}
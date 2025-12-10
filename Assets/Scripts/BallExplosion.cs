using UnityEngine;

public class BallExplosion : MonoBehaviour
{
    [Header("Explosión")]
    public GameObject explosionPrefab;   // Prefab de la explosión
    public float explosionLifetime = 1f; // Tiempo antes de destruir la explosión

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Solo reaccionar si chocamos con otra bola
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Punto medio entre las dos bolas para colocar la explosión
            Vector2 explosionPos = (transform.position + collision.transform.position) / 2f;

            // Instanciar la explosión
            if (explosionPrefab != null)
            {
                GameObject explosion = Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
                Destroy(explosion, explosionLifetime);
            }

            // Destruir ambas bolas
            Destroy(collision.gameObject); // la otra bola
            Destroy(gameObject);           // esta bola
        }
    }
}

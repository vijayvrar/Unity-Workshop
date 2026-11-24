using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collect the coin only when the Player touches it.
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin Collected!");
            Destroy(gameObject);
        }
    }
}

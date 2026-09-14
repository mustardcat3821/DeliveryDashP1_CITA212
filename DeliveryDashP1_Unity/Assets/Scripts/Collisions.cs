using UnityEngine;

public class Collisions : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Car has collided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Car has triggered with " + collision.gameObject.name);
    }
}

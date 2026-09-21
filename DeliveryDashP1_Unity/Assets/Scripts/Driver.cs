using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 0.05f;
    SpriteRenderer carRender;

    bool hasPackage = false;
    bool hasDelivered = true;

    void Start()
    {
        carRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float steerAmount = 0f;
        float moveAmount = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            moveAmount = 1f;
        }

        else if (Keyboard.current.sKey.isPressed)
        {
            moveAmount = -1f;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            steerAmount = 1f;
        }

        else if (Keyboard.current.dKey.isPressed)
        {
            steerAmount = -1f;
        }

        float steerFactor = steerAmount * steerSpeed * Time.deltaTime;
        float moveFactor = moveAmount * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, steerFactor);
        transform.Translate(0, moveFactor, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasPackage && other.CompareTag("Trigger") && hasDelivered)
        {
            hasPackage = true;
            hasDelivered = false;
            Debug.Log("Player triggered with Package! " + other.gameObject.name);
            Debug.Log("hasPackage: " + hasPackage);
            Destroy(other.gameObject);
        }

        if (hasPackage && other.CompareTag("Customer") && !hasDelivered)
        {
            hasPackage = false;
            hasDelivered = true;
            Debug.Log("Player triggered with Customer! " + other.gameObject.name);
            Debug.Log("hasDelivered: " + hasDelivered);
        }
    }
}

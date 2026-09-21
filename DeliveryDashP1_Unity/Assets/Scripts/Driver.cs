using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float currentSpeed = 5f;

    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 5f;

    [SerializeField] TMP_Text boostText;
    SpriteRenderer carRender;

    bool hasPackage = false;
    bool hasDelivered = true;

    void Start()
    {
        carRender = GetComponent<SpriteRenderer>();
        boostText.gameObject.SetActive(false);
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
        float moveFactor = moveAmount * currentSpeed * Time.deltaTime;

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
            GetComponent<ParticleSystem>().Play();
        }

        if (hasPackage && other.CompareTag("Customer") && !hasDelivered)
        {
            hasPackage = false;
            hasDelivered = true;
            Debug.Log("Player triggered with Customer! " + other.gameObject.name);
            Debug.Log("hasDelivered: " + hasDelivered);
            Destroy(other.gameObject);
            GetComponent<ParticleSystem>().Stop();
        }

        if (other.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Debug.Log("Boost activated! Current speed: " + currentSpeed);
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
        boostText.gameObject.SetActive(false);
    }
}

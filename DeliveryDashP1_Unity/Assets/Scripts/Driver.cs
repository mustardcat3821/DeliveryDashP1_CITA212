using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.5f;
    [SerializeField] float moveSpeed = 0.05f;
    
    void Start()
    {
        
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
}

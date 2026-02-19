using UnityEngine;
using UnityEngine.InputSystem;   // This goes at the TOP of the file

public class Paddle1 : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }
}
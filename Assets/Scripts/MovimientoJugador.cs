using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    private Rigidbody rb;
    private bool estaEnSuelo = false;
    private Vector2 touchStart;
    private bool tocando = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        // Controles teclado
        if (Keyboard.current != null)
        {
            if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
                horizontal = 1f;
            else if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
                horizontal = -1f;

            if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
                vertical = 1f;
            else if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
                vertical = -1f;

            if (Keyboard.current.spaceKey.wasPressedThisFrame && estaEnSuelo)
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }

        // Controles tactiles
        if (Touchscreen.current != null && Touchscreen.current.touches.Count > 0)
        {
            var touch = Touchscreen.current.touches[0];

            if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
            {
                touchStart = touch.position.ReadValue();
                tocando = true;
            }
            else if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Moved && tocando)
            {
                Vector2 delta = touch.position.ReadValue() - touchStart;

                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                    horizontal = Mathf.Sign(delta.x);
                else
                    vertical = Mathf.Sign(delta.y);
            }
            else if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended)
            {
                tocando = false;
                horizontal = 0f;
                vertical = 0f;
            }
        }

        Vector3 movimiento = new Vector3(horizontal, 0, vertical);
        rb.AddForce(movimiento * velocidad);
    }

    void OnCollisionEnter(Collision collision)
    {
        estaEnSuelo = true;
        SeguirJugador zona = FindAnyObjectByType<SeguirJugador>();
        if (zona != null)
            zona.BajarZona();
    }

    void OnCollisionExit(Collision collision)
    {
        estaEnSuelo = false;
    }
}
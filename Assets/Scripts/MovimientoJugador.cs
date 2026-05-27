using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    private Rigidbody rb;
    private bool estaEnSuelo = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
            horizontal = 1f;
        else if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            horizontal = -1f;

        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
            vertical = 1f;
        else if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
            vertical = -1f;

        Vector3 movimiento = new Vector3(horizontal, 0, vertical);
        rb.AddForce(movimiento * velocidad);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && estaEnSuelo)
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
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
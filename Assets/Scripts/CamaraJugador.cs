using UnityEngine;

public class CamaraJugador : MonoBehaviour
{
    public Transform jugador;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - jugador.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            jugador.position.x + offset.x,
            jugador.position.y + offset.y,
            jugador.position.z + offset.z
        );
    }
}
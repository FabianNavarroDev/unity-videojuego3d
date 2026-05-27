using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador;
    public float offsetY = -25f;
    public float velocidadBajada = 3f;

    private float objetivoY;
    private bool bajando = false;

    void Start()
    {
        objetivoY = transform.position.y;
    }

    void Update()
    {
        if (bajando)
        {
            transform.position = new Vector3(
                transform.position.x,
                Mathf.MoveTowards(transform.position.y, objetivoY, velocidadBajada * Time.deltaTime),
                transform.position.z
            );

            if (Mathf.Approximately(transform.position.y, objetivoY))
                bajando = false;
        }
    }

    public void BajarZona()
    {
        float nuevaY = jugador.position.y + offsetY;
        if (nuevaY < objetivoY)
        {
            objetivoY = nuevaY;
            bajando = true;
        }
    }
}
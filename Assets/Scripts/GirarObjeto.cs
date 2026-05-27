using UnityEngine;

public class GirarObjeto : MonoBehaviour
{
    public float velocidadRotacion = 10f;

    void Update()
    {
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }
}
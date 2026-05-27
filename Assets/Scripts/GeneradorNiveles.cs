using UnityEngine;

public class GeneradorNiveles : MonoBehaviour
{
    public GameObject prefabPlataforma;
    public int cantidadInicial = 10;
    public float separacionEntreNiveles = 3f;
    public float incrementoDificultad = 0.1f;

    private float ultimaYGenerada = 0f;
    private Transform jugador;
    private int nivelActual = 0;

    void Start()
    {
        jugador = GameObject.FindWithTag("Player").transform;

        for (int i = 0; i < cantidadInicial; i++)
        {
            GenerarPlataforma();
        }
    }

    void Update()
    {
        if (jugador.position.y < ultimaYGenerada + 10f)
        {
            GenerarPlataforma();
        }
    }

    void GenerarPlataforma()
    {
        float x = Random.Range(-2f, 2f);
        float z = Random.Range(-2f, 2f);
        Vector3 pos = new Vector3(x, ultimaYGenerada, z);
        Instantiate(prefabPlataforma, pos, Quaternion.identity);

        nivelActual++;
        separacionEntreNiveles += incrementoDificultad;

        ultimaYGenerada -= separacionEntreNiveles;
    }
}
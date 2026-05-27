using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ZonaMuerte : MonoBehaviour
{
    public GameObject efectoSplash;
    public float delayReinicio = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (efectoSplash != null)
                Instantiate(efectoSplash, other.transform.position, Quaternion.identity);

            other.gameObject.SetActive(false);
            StartCoroutine(ReiniciarEscena());
        }
    }

    IEnumerator ReiniciarEscena()
    {
        yield return new WaitForSeconds(delayReinicio);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
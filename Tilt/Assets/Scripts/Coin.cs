using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int spwan = 0;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameObject.SetActive(false);
        spwan = UnityEngine.Random.Range(1, 11);

        if (spwan > 5)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Coin Collected");
            audioSource.Play();
            StartCoroutine(DestroyCoinAfterDelay(0.1f));
        }
    }

    private IEnumerator DestroyCoinAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}

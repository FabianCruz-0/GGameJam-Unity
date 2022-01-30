using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
        public AudioClip clip;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        AudioSource.PlayClipAtPoint(clip,  Camera.main.transform.position,0.8f);
        }
        else if (other.CompareTag("Enemy"))
        {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position,0.8f);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().health += 1;
            Destroy(gameObject);

        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().health += 1;
            Destroy(gameObject);
        }
    }
}

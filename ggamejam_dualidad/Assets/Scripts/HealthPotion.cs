using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().health+=1;
            Destroy(gameObject);
        } else if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().health+=1;
            Destroy(gameObject);
        }
    }
}

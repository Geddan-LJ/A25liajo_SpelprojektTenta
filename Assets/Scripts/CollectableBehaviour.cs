using System;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlatformerMovement>().OnCollected();
            
            Destroy(gameObject);
        }
    }
}

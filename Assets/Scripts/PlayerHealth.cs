using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private List<Image> healthImages;
    
    private int maxPlayerHealth;
    private int playerHealth = 3;

    private void Start()
    {
        for (int i = 0; i < healthImages.Count; i++)
        {
            healthImages[i].gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Harmfull"))
        {
            playerHealth--;

            if (playerHealth > 0)
            {
                healthImages[playerHealth].gameObject.SetActive(false);
            }
            else if (playerHealth == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}

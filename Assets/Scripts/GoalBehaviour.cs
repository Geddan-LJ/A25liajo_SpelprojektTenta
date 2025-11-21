using System;
using UnityEngine;
using TMPro;

public class GoalBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountOfScoresText;
    [SerializeField] private GameObject footballPrefab;
    [SerializeField] private Transform footballSpawnPos;
    
    int amountOfScores = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Football"))
        {
            Destroy(other.gameObject);
            amountOfScores++;
            
            amountOfScoresText.text = amountOfScores.ToString() + " scores / 3";
            
            Instantiate(footballPrefab, footballSpawnPos.position, Quaternion.identity);
        }
    }
}

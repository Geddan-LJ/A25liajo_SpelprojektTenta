using System;
using UnityEngine;
using TMPro;

public class GoalBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountOfScoresText;
    [SerializeField] private GameObject footballPrefab;
    [SerializeField] private Transform footballSpawnPos;
    [SerializeField] private GameObject pathBlockerObj;
    
    int amountOfScores = 0;
    
    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Football"))
        {
            Destroy(other.gameObject);
            amountOfScores++;
            
            amountOfScoresText.text = amountOfScores.ToString() + " scores / 3";

            if (amountOfScores == 3 && !finished)
            {
                finished = true;
                
                pathBlockerObj.SetActive(false);
            }
            
            Instantiate(footballPrefab, footballSpawnPos.position, Quaternion.identity);
        }
    }
}

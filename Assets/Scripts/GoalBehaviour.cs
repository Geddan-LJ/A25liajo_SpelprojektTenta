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

    ParticleSystem particles;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject football = GameObject.Find("Football(Clone)");

            if (football != null)
            {
                Destroy(football);
                Instantiate(footballPrefab, footballSpawnPos.position, Quaternion.identity);
            }
        }
    }

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
                
                particles.Play();
                
                pathBlockerObj.SetActive(false);
            }
            
            Instantiate(footballPrefab, footballSpawnPos.position, Quaternion.identity);
        }
    }
}

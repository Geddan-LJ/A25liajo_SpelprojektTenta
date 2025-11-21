using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class NpcScript : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Sprite npcImage;
    [SerializeField] private string npcName;
    [SerializeField] private List<string> dialogue;
    [SerializeField] private float talkDistance; 
    [Header("Dialogue References")]
    [SerializeField] private GameObject dialogueBoxObj;
    [SerializeField] private Image npcImageRef;
    [SerializeField] private TextMeshProUGUI npcNameRef;
    [SerializeField] private TextMeshProUGUI dialogueTextRef;
    [SerializeField] private Button continueDialogueButton;
    [Header("Other References")]
    [SerializeField] Transform player;
    [SerializeField] private GameObject footballPrefab;
    [SerializeField] private Transform footballSpawnPoint;
    
    private int dialogueIndex;
    private bool finishedDialogue = false;

    private void Start()
    {
        continueDialogueButton.onClick.AddListener(ContinueDialogue);
        finishedDialogue = false;
    }

    private void Update()
    {
        float playerPos = player.position.x - transform.position.x;

        if (playerPos < 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (playerPos > 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        }
        
        float distance  = Vector2.Distance(player.position, transform.position);

        if (distance <= talkDistance)
        {
            if (!finishedDialogue || finishedDialogue && Input.GetKeyDown(KeyCode.E))
            {
                StartDialogue();
            }
        }
        else
        {
            StopDialogue();
        }
    }

    private void StartDialogue()
    {
        dialogueBoxObj.SetActive(true);
        npcImageRef.sprite = npcImage;
        npcNameRef.text = npcName;
        continueDialogueButton.enabled = true;
        
        dialogueTextRef.text = dialogue[dialogueIndex];
    }

    private void ContinueDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex >= dialogue.Count)
        {
            dialogueIndex = 0;
            
            if (!finishedDialogue)
            {
                Instantiate(footballPrefab, footballSpawnPoint.position, Quaternion.identity);
                finishedDialogue = true;
            }
            
            StopDialogue();
        }
        else
        {
            dialogueTextRef.text = dialogue[dialogueIndex];
        }
    }
    
    private void StopDialogue()
    {
        dialogueIndex = 0;
        dialogueBoxObj.SetActive(false);
    }
}

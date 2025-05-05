using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkullNpcDialogue : MonoBehaviour
{
    [Header("UI ¼³Á¤")]
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private TextMeshProUGUI dialogueText;      


    private void Awake()
    {
        
        dialogueUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        int clearedWave = 0;

        if (MinigameManager.instance != null)
            clearedWave = MinigameManager.instance.lastClearedWave;

        dialogueText.text = $"The wave of the mini game you cleared just before is {clearedWave}";
        dialogueUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.SetActive(false);
        }
    }
}

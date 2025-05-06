using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkullNpcDialogue : MonoBehaviour
{
    [Header("UI 설정")]
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

        //int clearedWave = 0;

        //if (MinigameManager.instance != null)
        //    clearedWave = MinigameManager.instance.lastClearedWave;

        dialogueText.text = $"미니게임을 진행하려면 방안의 분수를 살펴봐!";
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

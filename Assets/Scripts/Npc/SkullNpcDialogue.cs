using System.Collections;
using System.Collections.Generic;
using System.Text;
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

        if (ScoreManager.Instance.LastClearWave == 0)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"오늘은 아직 미니게임을 진행하지 않았네.");
            sb.AppendLine($"미니게임을 진행하려면 방안의 분수를 살펴봐!");
            dialogueText.text = sb.ToString();
        }
        else
        {
            var sb = new StringBuilder();
            sb.AppendLine($"기록을 보고싶으면 입구 양옆의 배너를 확인해봐!");
            sb.AppendLine($"다시 게임을하고 싶으면 분수대를 다시 조사해봐!");
            dialogueText.text = sb.ToString();
        }

        
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

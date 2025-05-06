using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreboardDialogue : MonoBehaviour
{
    [Header("UI ����")]
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

        var mgr = ScoreManager.Instance;

        if(mgr.BestScore <= 0)
        {
            dialogueText.text = "��� ����";
            dialogueUI.SetActive(true);
            return;
        }

        int bestScore = mgr.BestScore;
        int bestClearWave = mgr.BestClearWave;
        int bestMonsterCount = mgr.BestMonsterCount;
        float bestElapsedTime = mgr.BestElapsedTime;


        var sb = new StringBuilder();
        sb.AppendLine($"�ְ� ���ھ�: {bestScore}");
        sb.AppendLine($"��ƾ ���̺�: {bestClearWave}");
        sb.AppendLine($"��ƾ �ð�: {bestElapsedTime:F2}��");
        sb.AppendLine($"�� óġ ����: {bestMonsterCount}");
        
        dialogueText.text = sb.ToString();
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

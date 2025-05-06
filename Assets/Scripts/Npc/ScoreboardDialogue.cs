using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardDialogue : MonoBehaviour
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

        if(mgr.LastClearWave == 0)
        {
            dialogueText.text = "��� ����";
            dialogueUI.SetActive(true);
            return;
        }

        int finalScore = mgr.GetFinalScore();
        int waveSurvived = mgr.LastClearWave;
        int totalKills = mgr.TotalMonsterCount;
        float elapsedSeconds = mgr.ElapsedTime;


        var sb = new StringBuilder();
        sb.AppendLine($"���� ���ھ�: {finalScore}");
        sb.AppendLine($"��ƾ ���̺�: {waveSurvived}");
        sb.AppendLine($"��ƾ �ð�: {elapsedSeconds:F1}��");
        sb.AppendLine($"�� óġ ����: {totalKills}");
        sb.AppendLine("���ͺ� óġ:");
        foreach (var kv in mgr.KillCounts)
        {
            sb.AppendLine($"  {kv.Key} : {kv.Value}");
        }
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

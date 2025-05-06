using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardDialogue : MonoBehaviour
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

        var mgr = ScoreManager.Instance;

        if(mgr.LastClearWave == 0)
        {
            dialogueText.text = "기록 없음";
            dialogueUI.SetActive(true);
            return;
        }

        int finalScore = mgr.GetFinalScore();
        int waveSurvived = mgr.LastClearWave;
        int totalKills = mgr.TotalMonsterCount;
        float elapsedSeconds = mgr.ElapsedTime;


        var sb = new StringBuilder();
        sb.AppendLine($"최종 스코어: {finalScore}");
        sb.AppendLine($"버틴 웨이브: {waveSurvived}");
        sb.AppendLine($"버틴 시간: {elapsedSeconds:F1}초");
        sb.AppendLine($"총 처치 몬스터: {totalKills}");
        sb.AppendLine("몬스터별 처치:");
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

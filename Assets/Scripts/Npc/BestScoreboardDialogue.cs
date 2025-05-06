using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreboardDialogue : MonoBehaviour
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

        if(mgr.BestScore <= 0)
        {
            dialogueText.text = "기록 없음";
            dialogueUI.SetActive(true);
            return;
        }

        int bestScore = mgr.BestScore;
        int bestClearWave = mgr.BestClearWave;
        int bestMonsterCount = mgr.BestMonsterCount;
        float bestElapsedTime = mgr.BestElapsedTime;


        var sb = new StringBuilder();
        sb.AppendLine($"최고 스코어: {bestScore}");
        sb.AppendLine($"버틴 웨이브: {bestClearWave}");
        sb.AppendLine($"버틴 시간: {bestElapsedTime:F2}초");
        sb.AppendLine($"총 처치 몬스터: {bestMonsterCount}");
        
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

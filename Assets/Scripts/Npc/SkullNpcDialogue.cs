using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkullNpcDialogue : MonoBehaviour
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

        if (ScoreManager.Instance.LastClearWave == 0)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"������ ���� �̴ϰ����� �������� �ʾҳ�.");
            sb.AppendLine($"�̴ϰ����� �����Ϸ��� ����� �м��� �����!");
            dialogueText.text = sb.ToString();
        }
        else
        {
            var sb = new StringBuilder();
            sb.AppendLine($"����� ��������� �Ա� �翷�� ��ʸ� Ȯ���غ�!");
            sb.AppendLine($"�ٽ� �������ϰ� ������ �м��븦 �ٽ� �����غ�!");
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

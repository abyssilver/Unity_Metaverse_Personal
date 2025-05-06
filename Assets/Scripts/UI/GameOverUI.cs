using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI currentWave;
    [SerializeField] private TextMeshProUGUI totalMonsterCount;
    [SerializeField] private TextMeshProUGUI elapsedTime;

    [SerializeField] private TextMeshProUGUI monsterListText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void OnEnable()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        var mgr = ScoreManager.Instance; //���۸� �ϴ� �߰��ߴµ� �Ź��ؼ� �ẽ. �� �⺻����������..

        currentScore.text = mgr.GetFinalScore().ToString();
        currentWave.text = mgr.LastClearWave.ToString();
        totalMonsterCount.text = mgr.TotalMonsterCount.ToString();
        elapsedTime.text = mgr.ElapsedTime.ToString("F2");

        string listStr = "";
        foreach (var kv in mgr.KillCounts)
        {
            // óġ�� ���͸�
            if (kv.Value > 0)
                listStr += $"{kv.Key}       {kv.Value}\n";
        }
        monsterListText.text = listStr;
    }
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickExitButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}

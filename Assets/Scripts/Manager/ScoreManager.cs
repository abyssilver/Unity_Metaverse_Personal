using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int LastClearWave { get; set; }
    public int TotalMonsterCount { get; private set; } 
    public int TotalMonsterScore { get; private set; }
    
    private float startTime;
    private float elapsedTime;

    public int FinalScore { get; private set; }

    private Dictionary<string, int> killCounts = new Dictionary<string, int>();

    public IReadOnlyDictionary<string, int> KillCounts => killCounts;
    public float ElapsedTime => elapsedTime;

    //최고기록용
    private int bestScore;
    private int bestClearWave;
    private int bestMonsterCount;
    private float bestElapsedTime;
    private Dictionary<string, int> bestKillCounts = new Dictionary<string, int>();

    public int BestScore => bestScore;
    public int BestClearWave => bestClearWave;
    public int BestMonsterCount => bestMonsterCount;
    public float BestElapsedTime => bestElapsedTime;
    public IReadOnlyDictionary<string, int> BestKillCounts => bestKillCounts;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadBestRecord();
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public void StartGame()
    {
        TotalMonsterCount = 0;
        TotalMonsterScore = 0;
        killCounts.Clear();
        startTime = Time.time;
        elapsedTime = 0f;
    }
    public void OnGameOver()
    {
        elapsedTime = Time.time - startTime;
        int currentScore = GetFinalScore();
        UpdateBestRecord(currentScore);
    }

    public void AddMonsterScore(string monsterName, int monsterScore)
    {
        TotalMonsterScore += monsterScore;
        TotalMonsterCount++;

        if (killCounts.ContainsKey(monsterName))
        {
            killCounts[monsterName]++;
        }
        else
        {
            killCounts[monsterName] = 1;
        }
    }
    public int GetKillCount(string monsterName)
    {
        return killCounts.TryGetValue(monsterName, out var cnt) ? cnt : 0;
    }
    public int GetFinalScore()
    {
        int timeBonus = Mathf.FloorToInt(elapsedTime * 2f);

        FinalScore = LastClearWave * 10 + TotalMonsterScore + timeBonus;
        return FinalScore;
    }
    private void UpdateBestRecord(int currentScore)
    {
        if (currentScore <= bestScore) return;
        bestScore = currentScore;
        bestClearWave = LastClearWave;
        bestMonsterCount = TotalMonsterCount;
        bestElapsedTime = elapsedTime;

        bestKillCounts.Clear();
        foreach (var kv in killCounts)
            bestKillCounts[kv.Key] = kv.Value;

        SaveBestRecord();
    }
    private void SaveBestRecord()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
        PlayerPrefs.SetInt("BestClearWave", bestClearWave);
        PlayerPrefs.SetInt("BestMonsterCount", bestMonsterCount);
        PlayerPrefs.SetFloat("BestElapsedTime", bestElapsedTime);
        PlayerPrefs.Save();
    }

    private void LoadBestRecord()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestClearWave = PlayerPrefs.GetInt("BestClearWave", 0);
        bestMonsterCount = PlayerPrefs.GetInt("BestMonsterCount", 0);
        bestElapsedTime = PlayerPrefs.GetFloat("BestElapsedTime", 0f);
    }

}

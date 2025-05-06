using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int LastClearWave { get; set; }
    //public int bestClearWave = 0;
    public int TotalMonsterCount { get; private set; } 
    public int TotalMonsterScore { get; private set; }
    
    private float startTime;
    private float elapsedTime;

    public int FinalScore { get; private set; }

    private Dictionary<string, int> killCounts = new Dictionary<string, int>();

    public IReadOnlyDictionary<string, int> KillCounts => killCounts;
    public float ElapsedTime => elapsedTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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



}

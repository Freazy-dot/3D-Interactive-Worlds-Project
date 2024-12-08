using System;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    private int teamPoints;

    public static Points Instance { get; private set; }

    [SerializeField]private TextMeshProUGUI pointsText;

    public event Action<int> LevelUp;
    public int level { get; private set; } = 1;
    [SerializeField]private int levelUpThreshold = 100;

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }

        else {
            Instance = this;
        }

        pointsText.text = $"Points: {teamPoints}";
    }

    public void AddPoints(int amount)
    {
        teamPoints += amount;
        Debug.Log($"Points Added: {amount} | Total Team Points: {teamPoints}");

        if (teamPoints >= levelUpThreshold) {
            level++;
            LevelUp?.Invoke(teamPoints);
            levelUpThreshold = (int)(teamPoints + (50 * level));
        }
    }

    public int GetPoints()
    {
        return teamPoints;
    }   


    public void Update()
    {
        pointsText.text = $"Points: {teamPoints}";
    }
}

using UnityEngine;

public class Points : MonoBehaviour
{
    private int teamPoints;

    public static Points Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }

        else {
            Instance = this;
        }
    }

    public void AddPoints(int amount)
    {
        teamPoints += amount;
        Debug.Log($"Points Added: {amount} | Total Team Points: {teamPoints}");
    }

    public int GetPoints()
    {
        return teamPoints;
    }
}

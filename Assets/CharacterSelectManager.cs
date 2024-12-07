using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
   public static CharacterSelectManager Instance { get; private set; }
    public GameObject selectedCharacter; // Prefab of the selected character

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
    }
}

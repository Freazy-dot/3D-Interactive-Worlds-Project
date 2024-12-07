using UnityEngine;

public class GameplayManager : MonoBehaviour
{
      public Transform spawnPoint; // Where the character spawns

    private void Start()
    {
        if (CharacterSelectManager.Instance != null && CharacterSelectManager.Instance.selectedCharacter != null)
        {
            Instantiate(CharacterSelectManager.Instance.selectedCharacter, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("No character selected!");
        }
    }
}

using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
   public GameObject MeleeCharacter;
    public GameObject RangedCharacter;

    public void SelectMeleeCharacter()
    {
        CharacterSelectManager.Instance.selectedCharacter = MeleeCharacter;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Arena");
    }

    public void SelectRangedCharacter()
    {
        CharacterSelectManager.Instance.selectedCharacter = RangedCharacter;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Arena");
    }
    
}

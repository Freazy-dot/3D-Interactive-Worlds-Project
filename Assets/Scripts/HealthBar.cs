using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Canvas healthBarCanvas;
    [SerializeField] private Image healthBarFill;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (mainCamera == null) {
            Debug.LogWarning("Main camera not found!");
            return;
        }

        healthBarCanvas.transform.LookAt(mainCamera.transform);
        healthBarCanvas.transform.Rotate(0, 180, 0); // Correct rotation
    }

    public void UpdateHealth(float health, float maxHealth)
    {
        Debug.Log($"Updating HealthBar: health = {health}, maxHealth = {maxHealth}");
        healthBarFill.fillAmount = health / maxHealth;
    }
}

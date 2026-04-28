using Unity.Cinemachine;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] int startingHealth = 5;
    [SerializeField] CinemachineCamera deathVirtualCamera;
    [SerializeField] Transform weaponCamera;
    [SerializeField] Image[] shieldBars;

    int gameOverVirtualCameraPriority = 20;
    private int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
        AdjustShieldUI();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        AdjustShieldUI();

        if (currentHealth <= 0)
        {
            weaponCamera.parent = null;
            deathVirtualCamera.Priority = gameOverVirtualCameraPriority;
            Destroy(this.gameObject);
        }
    }
    void AdjustShieldUI()
    {
        for (int i = 0; i < shieldBars.Length; i++)
        {
            if (i < currentHealth)
            {
                shieldBars[i].gameObject.SetActive(true);
            }
            else
            {
                shieldBars[i].gameObject.SetActive(false);
            }
        }
    }
}

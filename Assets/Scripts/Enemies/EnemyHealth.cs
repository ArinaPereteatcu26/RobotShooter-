using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotExplosionVFX;
    [SerializeField] int startingHealth = 3;
    private int currentHealth;

    GameManager gameManager;

    void Awake()
    {
        currentHealth = startingHealth;
        Debug.Log($"{gameObject.name} starting health = {currentHealth}");
    }

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"{gameObject.name} took damage. Current health = {currentHealth}");

        if (currentHealth <= 0)
        {
            gameManager.AdjustEnemiesLeft(-1);
           SelfDestruct();
        }
    }
    public void SelfDestruct()
    {
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
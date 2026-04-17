using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
    private int currentHealth;

    void Awake()
    {
        currentHealth = startingHealth;
        Debug.Log($"{gameObject.name} starting health = {currentHealth}");
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"{gameObject.name} took damage. Current health = {currentHealth}");

        if (currentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} destroyed");
            Destroy(gameObject);
        }
    }
}
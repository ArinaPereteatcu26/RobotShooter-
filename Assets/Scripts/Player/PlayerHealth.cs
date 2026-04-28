using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 5;
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
            Destroy(this.gameObject);
        }
    }
}

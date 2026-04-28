using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject robotExplosionVFX;
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
           SelfDestruct();
        }
    }
    public void SelfDestruct()
    {
        Instantiate(robotExplosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
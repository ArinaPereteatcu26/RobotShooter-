using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] private float range = 100f;


    public void Shoot(WeaponSO weaponSO)
    {
      

        RaycastHit hit; 
        muzzleFlash.Play();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
           
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(weaponSO.Damage);

                if (weaponSO.HitVFXPrefab != null)
                {
                    Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                }
                
            }
            else
            {
                Debug.Log("Hit object has no EnemyHealth component.");
            }
        }

       
    }
}
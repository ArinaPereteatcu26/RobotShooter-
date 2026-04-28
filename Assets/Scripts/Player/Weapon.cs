using Unity.Cinemachine;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] private float range = 100f;
    [SerializeField] LayerMask interactionLayers;

    CinemachineImpulseSource impulseSource;
    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }


    public void Shoot(WeaponSO weaponSO)
    {
      

        RaycastHit hit; 
        muzzleFlash.Play();
        impulseSource.GenerateImpulse();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range, interactionLayers, QueryTriggerInteraction.Ignore))
        {
           
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

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
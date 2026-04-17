using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private StarterAssetsInputs starterAssetsInputs;

    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float range = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Animator animator;

    const string SHOOT_STRING = "Shooting";

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();

        if (starterAssetsInputs == null)
        {
            Debug.LogError("StarterAssetsInputs was not found in parent objects.");
        }
    }

    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (starterAssetsInputs == null) return;
        if (!starterAssetsInputs.shoot) return;
        if (Camera.main == null)
        {
            Debug.LogError("Main Camera not found. Make sure your camera has the MainCamera tag.");
            starterAssetsInputs.ShootInput(false);
            return;
        }

        muzzleFlash.Play();

        animator.Play(SHOOT_STRING, 0, 0f);
        starterAssetsInputs.ShootInput(false);

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name);

            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);

                if (hitVFXPrefab != null)
                {
                    Instantiate(hitVFXPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
            else
            {
                Debug.Log("Hit object has no EnemyHealth component.");
            }
        }

       
    }
}
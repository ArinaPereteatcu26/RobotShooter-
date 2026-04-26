using JetBrains.Annotations;
using StarterAssets;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    

    [SerializeField] WeaponSO weaponSO;
    Animator animator;

    private StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;

    const string SHOOT_STRING = "Shooting";

    float timeSinceLastShot = 0f;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();

        if (currentWeapon == null)
        {
            Debug.LogError("Weapon component not found in children.");
        }
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
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
        if (timeSinceLastShot >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
        }

        if (!weaponSO.IsAutomatic)
        {
            starterAssetsInputs.ShootInput(false);

        }
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponent<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
    }
    void HandleZoom()
    {
        if (!weaponSO.CanZoom) return;

        if (starterAssetsInputs.zoom)
        {
            Debug.Log("zoomed in");
        }
        else
        {
            Debug.Log("not zoomed in");
        }

    }
}


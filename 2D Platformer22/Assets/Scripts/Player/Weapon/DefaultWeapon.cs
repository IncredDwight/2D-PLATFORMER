
public class DefaultWeapon : Weapon
{
    private void Start()
    {
        WeaponSetUp(0.2f, 60, FindObjectOfType<DefaultWeaponProjectile>().gameObject);
    }
}

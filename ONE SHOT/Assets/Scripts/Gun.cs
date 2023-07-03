using UnityEngine;

public class Gun : MonoBehaviour
{
    public int Damage = 50;
    public float Range = 100f;

    public ParticleSystem muzzleFlash;
    public float FireRate = 15f;
    public Camera fpsCam;
    [SerializeField] AudioSource GunSound;

    private float nextTimeToFire = 2f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            GunSound.Play();
            nextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit Hit;
        if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out Hit,Range))
        {
            Debug.Log(Hit.transform.name);
            Target target = Hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(Damage);
            }
        }
    }

}

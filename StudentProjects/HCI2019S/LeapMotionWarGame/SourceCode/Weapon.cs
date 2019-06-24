
//using UnityEngine;
//using UnityEngine.UI;

//public class Weapon : MonoBehaviour {

//    // Weapon Specification
//    public string weaponName;
//    public int bulletsPerMag;
//    public int bulletsTotal;
//    public int currentBullets;
//    public float range;
//    public float fireRate;
//    public Text bulletsText;



//    // Parameters
//    private float fireTimer;
//    private bool isReloading = false;


//    // References
//    public Transform shootPoint;
//    public AudioClip shootSound;
//    public AudioSource audioSource;
//    public ParticleSystem muzzleFlash;
//    public AudioClip reloadSound;


//    private Animator anim;



//    // Use this for initialization
//    private void Start()
//    {
//        currentBullets = bulletsPerMag;
//        anim = GetComponent<Animator>();
//        bulletsText.text = currentBullets + " / " + bulletsTotal;


//    }

//    // Update is called once per frame
//    private void Update()
//    {
//        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
//        isReloading = info.IsName("Reload");

//        if (Input.GetButton("Fire1"))
//        {
//            if (currentBullets > 0)
//            {
//                Fire();
//            }
//            else
//            {
//                DoReload();
//            }
//        }

//        if (Input.GetKeyDown(KeyCode.R))
//        {
//            DoReload();
//        }



//        if (fireTimer < fireRate)
//        {
//            fireTimer += Time.deltaTime;
//        }


//    }

//    private void DoReload()
//    {
//        if (!isReloading && currentBullets < bulletsPerMag && bulletsTotal > 0)
//        {
//            anim.CrossFadeInFixedTime("Reload", 0.01f); // Reloading
//            audioSource.PlayOneShot(reloadSound);
//        }
//    }

//    public void Reload()
//    {
//        int bulletsToReload = bulletsPerMag - currentBullets;
//        if (bulletsToReload > bulletsTotal)
//        {
//            bulletsToReload = bulletsTotal;
//        }
//        currentBullets += bulletsToReload;
//        bulletsTotal -= bulletsToReload;
//        bulletsText.text = currentBullets + " / " + bulletsTotal;
//    }


//private void Fire()
//    {
//        if (fireTimer < fireRate || isReloading)
//        {
//            return;
//        }
//        Debug.Log("Shot Fired!");
//        RaycastHit hit;
//        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
//        {
//            Debug.Log("Hit!");
//        }
//        currentBullets--;
//        fireTimer = 0.0f;
//        audioSource.PlayOneShot(shootSound);
//        anim.CrossFadeInFixedTime("Fire", 0.01f); // fire animation

//        muzzleFlash.Play();
//        bulletsText.text = currentBullets + " / " + bulletsTotal;


//    }

//}


using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    // Weapon Specification
    public string weaponName;
    public int bulletsPerMag;
    public int bulletsTotal;
    public int currentBullets;
    public float range;
    public float fireRate;
    public Vector3 aimPosition;
    private Vector3 originalPosition;

    // Parameters
    private float fireTimer;
    private bool isReloading;
    private bool isAiming;

    // References
    public Transform shootPoint;
    private Animator anim;
    public ParticleSystem muzzleFlash;
    public Text bulletsText;

    // Prefabs
    public GameObject hitSparkPrefab;
    public GameObject hitHolePrefab;

    // Sounds
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    // Recoil
    public Transform camRecoil;
    public Vector3 recoilKickback;
    public float recoilAmount;

    //enemy damage
    float damage = 10f;

    // Use this for initialization
    private void Start()
    {
        currentBullets = bulletsPerMag;
        anim = GetComponent<Animator>();
        bulletsText.text = currentBullets + " / " + bulletsTotal;
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);
        isReloading = info.IsName("Reload");

        if (Input.GetButton("Fire1"))
        {
            if (currentBullets > 0)
            {
                Fire();
            }
            else
            {
                DoReload();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DoReload();
        }

        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
        AimDownSights();
        RecoilBack();
    }

    private void Fire()
    {
        if (fireTimer < fireRate || isReloading)
        {
            return;
        }
        Debug.Log("Fired!");
        RaycastHit hit;
        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Swat swat = hit.transform.GetComponent<Swat>();
            if (swat) {
                swat.ApplyDamage(damage);
            }

            GameObject hitSpark = Instantiate(hitSparkPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Destroy(hitSpark, 0.5f); // Destroying automatically
            GameObject hitHole = Instantiate(hitHolePrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Destroy(hitHole, 5f); // Destroying automatically
        }
        currentBullets--;
        fireTimer = 0.0f;
        anim.CrossFadeInFixedTime("Fire", 0.01f); // fire animation
        audioSource.PlayOneShot(shootSound); // shoot sound
        muzzleFlash.Play();
        bulletsText.text = currentBullets + " / " + bulletsTotal;
        Recoil();
    }

    private void DoReload()
    {
        if (!isReloading && currentBullets < bulletsPerMag && bulletsTotal > 0)
        {
            anim.CrossFadeInFixedTime("Reload", 0.01f); // Reloading
            audioSource.PlayOneShot(reloadSound);
        }
    }

    public void Reload()
    {
        int bulletsToReload = bulletsPerMag - currentBullets;
        if (bulletsToReload > bulletsTotal)
        {
            bulletsToReload = bulletsTotal;
        }
        currentBullets += bulletsToReload;
        bulletsTotal -= bulletsToReload;
        bulletsText.text = currentBullets + " / " + bulletsTotal;
    }

    private void AimDownSights()
    {
        if (Input.GetButton("Fire2") && !isReloading)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * 8f);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 40f, Time.deltaTime * 8f);
            isAiming = true;
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * 5f);
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60f, Time.deltaTime * 8f);
            isAiming = false;
        }
    }

    private void Recoil()
    {
        Vector3 recoilVector = new Vector3(Random.Range(-recoilKickback.x, recoilKickback.x), recoilKickback.y, recoilKickback.z);
        Vector3 recoilCamVector = new Vector3(-recoilVector.y * 400f, recoilVector.x * 200f, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + recoilVector, recoilAmount / 2f); // position recoil
        camRecoil.localRotation = Quaternion.Slerp(camRecoil.localRotation, Quaternion.Euler(camRecoil.localEulerAngles + recoilCamVector), recoilAmount); // cam recoil
    }

    private void RecoilBack()
    {
        camRecoil.localRotation = Quaternion.Slerp(camRecoil.localRotation, Quaternion.identity, Time.deltaTime * 2f);
    }

}
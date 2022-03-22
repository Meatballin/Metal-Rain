using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject referenceToAudio;
    public Transform firePoint;
    public Camera gameCamera;
    private int currentWeapon;

    //RIFLE CODE
    public GameObject rifleMuzzleFlash;
    public GameObject bulletPrefab;
    private bool isFlashing = false;
    private float rifleFireRate = 0.13f;
    private float framesFlashed;
    private float maxFlashFrames = 4.7f;
    private float lastShot = 0.0f;
    /*[SerializeField] private AudioSource source;
    [SerializeField] private AudioClip rifleBulletSound;
    [SerializeField] private AudioClip rifleLastBulletSound;*/

    //ROCKET LAUNCHER CODE
    public GameObject rocketPrefab;
    private float rpgFireRate = 0.35f;
   /* [SerializeField] private AudioClip rocketSound;*/
    
    private void Start()
    {
        referenceToAudio = GameObject.Find("AudioManager");
        //Always start game with m4
        currentWeapon = 1;
        //Makes sure muzzle flash is off on game start
        rifleMuzzleFlash.SetActive(false);

    }
    // Update is called once per frame
    private void Update()
    {
        //Function to handle weapon swapping
        weaponSwaps();
        //Handles which weapon we have equipped
        switch(currentWeapon)
        {
            case 1:
                RifleProfile();
                break;
            case 2:
                RPGProfile();
                break;
            
        }
       
    }

    private void weaponSwaps()
    {
        //Handles weapon swaps depending on 'Q' or 'E' press
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeapon != 1)
                currentWeapon--;
            if (currentWeapon == 1)
                currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentWeapon != 3)
                currentWeapon++;
            if (currentWeapon == 3)
                currentWeapon = 3;
        }
    }

    //Takes care of bullet fire rate
    private void RifleShoot()
    {
        if (Time.time > rifleFireRate + lastShot)
        {

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            lastShot = Time.time;

        }

    }

    private void RifleProfile()
    {
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        

        AimHandler();
        if (Input.GetButton("Fire1"))
        {
            RifleShoot();

            if (!isFlashing)
            {
                /*source.PlayOneShot(rifleBulletSound);*/
                FindObjectOfType<AudioManager>().Play("RifleBulletSound");
                StartCoroutine(RifleMuzzleFlash());
            }

        }
        if (Input.GetButtonUp("Fire1"))
        {
            /*source.PlayOneShot(rifleLastBulletSound);*/
            FindObjectOfType<AudioManager>().Play("RifleEndSound");
        }
    }

    private void RPGProfile()
    {
        //Turns off M4 and brings in RPG
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        
        AimHandler();
        if(Input.GetButtonDown("Fire1"))
        {
            RPGShoot();
        }
    }
    private void RPGShoot()
    {
        if (Time.time > rpgFireRate + lastShot)
        {

            Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
            FindObjectOfType<AudioManager>().Play("RocketLaunch");
            /*source.PlayOneShot(rocketSound);*/
            lastShot = Time.time;
            
        }
    }

    private void AimHandler()
    {
        Vector3 mousePos = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        firePoint.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        if (angle > 89 || angle < -89)
            localScale.y = -1f;
        else
            localScale.y = +1f;

        transform.localScale = localScale;

    }
    
    

    //function used to return angle that mouse ptr is at
    //Get Mouse Position in the World with Z = 0f
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    
    //Muzzle Flash for Rifle Animation
    IEnumerator RifleMuzzleFlash()
    {
        rifleMuzzleFlash.SetActive(true);
        framesFlashed = 0f;
        isFlashing = true;
        while(framesFlashed <= maxFlashFrames)
        {
            framesFlashed++;
            yield return null;
        }
        rifleMuzzleFlash.SetActive(false);
        isFlashing = false;
        
    }
}

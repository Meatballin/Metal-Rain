using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Total # of weapons in game
    const int totalNumWeapons = 4;

    private GameObject referenceToAudio;
    public Transform firePoint;
    public Camera gameCamera;
    private int currentWeapon;
    

    public GameObject weaponUI;

    //Array of booleans to handle weapon pickups
    [SerializeField] private bool[] weapons = new bool[totalNumWeapons];

    //DEAGLE CODE
    private float deagleFireRate = 0.25f;
    
    //RIFLE CODE
    public GameObject rifleMuzzleFlash;
    public GameObject bulletPrefab;
    private bool isFlashing = false;
    private float rifleFireRate = 0.1195f;
    private float framesFlashed;
    private float maxFlashFrames = 2f;
    private float lastShot = 0.0f;

    //ROCKET LAUNCHER CODE
    public GameObject rocketPrefab;
    private float rpgFireRate = 0.35f;

    //shotgun
    private float shotgunFireRate = 0.8f;
    public GameObject pellet;

    private void Start()
    {
        initializeWepScene();
        weaponUI.transform.Find("DeagleIcon").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

    }
    // Update is called once per frame
    private void Update()
    {
        //Function to handle weapon swapping
        weaponSwaps();
        //Handles which weapon we have equipped
        switch(currentWeapon)
        {
            case 0:
                DeagleProfile();
                break;
            case 1:
                RifleProfile();
                break;
            case 2:
                RPGProfile();
                break;
            case 3:
                ShotgunProfile();
                break;
            default:
                DeagleProfile();
                break;

        }
       
    }

    private void weaponSwaps()
    {
      
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
            weaponUI.transform.Find("M4Icon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
            weaponUI.transform.Find("DeagleIcon").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            weaponUI.transform.Find("RPGIcon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
            weaponUI.transform.Find("ShotgunIcon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weapons[1])
        {
            currentWeapon = 1;
            weaponUI.transform.Find("M4Icon").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            weaponUI.transform.Find("DeagleIcon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
            weaponUI.transform.Find("RPGIcon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
            weaponUI.transform.Find("ShotgunIcon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && weapons[2])
        {
            currentWeapon = 2;
            weaponUI.transform.Find("RPGIcon").gameObject.transform.localScale = new Vector3(1, 1f, 1f);
            weaponUI.transform.Find("M4Icon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
            weaponUI.transform.Find("DeagleIcon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
            weaponUI.transform.Find("ShotgunIcon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && weapons[3])
        {
            currentWeapon = 3;
            weaponUI.transform.Find("ShotgunIcon").gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            weaponUI.transform.Find("RPGIcon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
            weaponUI.transform.Find("M4Icon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
            weaponUI.transform.Find("DeagleIcon").gameObject.transform.localScale = new Vector3(.7f, .7f, .7f);
        }
    }

    private void initializeWepScene()
    {
        referenceToAudio = GameObject.Find("AudioManager");

        //Always start game with deagle and set 0 index of array to true
        
        currentWeapon = 0;
        weapons[0] = true;
        weapons[1] = false;
        weapons[2] = false;
        weapons[3] = false;

        //Makes sure muzzle flash is off on game start
        rifleMuzzleFlash.SetActive(false);
    }
    private void DeagleProfile()
    {
        //Turns off M4 and brings in RPG
        transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(3).gameObject.SetActive(false);


        AimHandler();
        if (Input.GetButton("Fire1"))
        {
            DeagleShoot();
        }
    }

    private void DeagleShoot()
    {
        if (Time.time > deagleFireRate + lastShot)
        {
            FindObjectOfType<AudioManager>().Play("DeagleSound");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            lastShot = Time.time;

        }
    }
    //Takes care of bullet fire rate
    private void RifleShoot()
    {
        if (Time.time > rifleFireRate + lastShot)
        {
            FindObjectOfType<AudioManager>().Play("RifleBulletSound");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            lastShot = Time.time;

        }

    }

    private void RifleProfile()
    {
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(3).gameObject.SetActive(false);



        AimHandler();
        if (Input.GetButton("Fire1"))
        {
            RifleShoot();

            if (!isFlashing)
                StartCoroutine(RifleMuzzleFlash());
            

        }
        
    }

    private void RPGProfile()
    {
        //Turns off M4 and brings in RPG
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        transform.GetChild(1).GetChild(3).gameObject.SetActive(false);


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

    private void shotgunShoot()
    {
        if (Time.time > shotgunFireRate + lastShot)
        {
            int bulletCount = 7;
            Quaternion newRotation = firePoint.rotation;
            float spread = 1;
            FindObjectOfType<AudioManager>().Play("ShotgunSound");
            for (int i = 0; i < bulletCount; i++)
            {
                float addedOffset = (i - (bulletCount / 2) * spread);
                newRotation = Quaternion.Euler(firePoint.transform.eulerAngles.x,
                                                firePoint.transform.eulerAngles.y,
                                                firePoint.transform.eulerAngles.z + addedOffset);

                Instantiate(pellet, firePoint.position, newRotation);
            }
            lastShot = Time.time;
        }
    }

    private void ShotgunProfile()
    {
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        AimHandler();
        if (Input.GetButton("Fire1"))
        {
            shotgunShoot();
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we run into M4 pickup
        if(collision.gameObject.layer == 11)
        {
            //set index 1 in boolean array to true, giving us m4 access
            weapons[1] = true;
            weaponUI.transform.Find("M4Icon").gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        //If we run into RPG pickup
        if(collision.gameObject.layer == 12)
        {
            weapons[2] = true;
            weaponUI.transform.Find("RPGIcon").gameObject.SetActive(true);
            
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.layer == 13)
        {
            weapons[3] = true;
            weaponUI.transform.Find("ShotgunIcon").gameObject.SetActive(true);

            Destroy(collision.gameObject);
        }


    }
}

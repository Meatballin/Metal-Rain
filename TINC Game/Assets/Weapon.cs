using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public Camera gameCamera;

    //RIFLE CODE
    public GameObject rifleMuzzleFlash;
    public GameObject bulletPreFab;
    private bool isFlashing = false;
    private float rifleFireRate = 0.1f;
    private float framesFlashed;
    private float maxFlashFrames = 4.7f;
    private float lastShot = 0.0f;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip rifleBulletSound;
    [SerializeField] private AudioClip rifleLastBulletSound;
    
    private void Start()
    {
        rifleMuzzleFlash.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        AimHandler();
        if (Input.GetButton("Fire1"))
        {
            RifleShoot();
            
            if(!isFlashing)
            {
                source.PlayOneShot(rifleBulletSound);
                StartCoroutine(RifleMuzzleFlash());
            }
            
        }
        if(Input.GetButtonUp("Fire1"))
        {
            source.PlayOneShot(rifleLastBulletSound);
        }
    }

    //Takes care of bullet fire rate
    private void RifleShoot()
    {
        if (Time.time > rifleFireRate + lastShot)
        {

            Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
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

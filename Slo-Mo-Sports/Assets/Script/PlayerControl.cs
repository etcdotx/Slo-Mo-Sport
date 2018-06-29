using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{   private float nexttimetofire = 0f;
    public float firerate =10f;
    private float speed = 45f;
    private float sensitivityX = 3F;
    public int currWeaponAmmo;
    public int maxWeaponAmmo;

    public TimeManager time;
    public Camera fpscam;
    public GameObject bullet;
    public Transform guns;
    public Transform spawnpoint;
    public Text text;
    public WeaponSwitch weapon;
    public AmmoDropManager1 ADM;
    public GameObject pause;
    public GameObject death;
    public CameraFPS cam;
 
    // Use this for initialization
    void Start()
    {
        cam = GetComponentInChildren<CameraFPS>();
        time = FindObjectOfType<TimeManager>();
        UpdateText();
        weapon = GetComponentInChildren<WeaponSwitch>();
        ADM = FindObjectOfType<AmmoDropManager1>().GetComponent<AmmoDropManager1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")|| Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.Escape))
        {
           
            if (Input.GetKey(KeyCode.W))
            {
                time.backtonormal();
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                time.backtonormal();
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                time.backtonormal();
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                time.backtonormal();
                transform.Translate(0, 0, -speed * Time.deltaTime);
            }
            if (Input.GetButtonDown("Fire1") && Time.time >= nexttimetofire && currWeaponAmmo>0 ) {
                nexttimetofire = Time.time + 1f / firerate;
                shoot();
                UpdateText();
            }
            if (Input.GetKey(KeyCode.Escape)) {
                pause.SetActive(true);
                Time.timeScale = 0f;
                cam.enabled = false;
                weapon.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                this.enabled = false;
            }
         
        }
        else
        {
            time.doslowmotion();
        }
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        transform.localEulerAngles = new Vector3(0, rotationX, 0);
    }
   

    void shoot() {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit)) {
  
        }
        Instantiate(bullet,spawnpoint.position,guns.rotation);
        currWeaponAmmo--;

    }


    public void UpdateText() {
        text.text = currWeaponAmmo + "/" + maxWeaponAmmo;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo") {
     
            AmmoDrop ammo = other.GetComponent<AmmoDrop>();
       
            if (currWeaponAmmo != maxWeaponAmmo || weapon.currammo[ammo.AmmoType] != weapon.maxammo[ammo.AmmoType])
            {
             
                if (weapon.selectedweapon == ammo.AmmoType)
                {
                    currWeaponAmmo += ammo.AmmoAmmount;
                    if (currWeaponAmmo > maxWeaponAmmo)
                    {
                        currWeaponAmmo = maxWeaponAmmo;
                    }
                }
                else
                {
                    weapon.currammo[ammo.AmmoType] += ammo.AmmoAmmount;
                    if (weapon.currammo[ammo.AmmoType] > weapon.maxammo[ammo.AmmoType])
                    {
                        weapon.currammo[ammo.AmmoType] = weapon.maxammo[ammo.AmmoType];
                    }

                }
                other.GetComponent<AmmoDrop>().AmmoActivate = false;
                other.gameObject.SetActive(false);
                ADM.ActivatedAmmoDrop--;
                UpdateText();
            }

        }
        if (other.gameObject.tag == "Bullet") {
            death.SetActive(true);
            Time.timeScale = 0f;
            cam.enabled = false;
            weapon.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            this.enabled = false;
        }
    }

}

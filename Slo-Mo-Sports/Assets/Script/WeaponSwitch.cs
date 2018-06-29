using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
    public int selectedweapon = 0;
    public float[] firerate;
    public int[] currammo;
    public int[] maxammo;

    private PlayerControl player;
    public GameObject[] bullet;
    public Transform[] spawnp;
    

    //index code 0 = basket, 1= golf,2 = tennis,etc
	void Awake () {
        player = FindObjectOfType<PlayerControl>();
        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () {
        int previouswselect = selectedweapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f){
            if (selectedweapon >= transform.childCount - 1) {
                selectedweapon = 0;
            }
            else
            {
                selectedweapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedweapon <= 0)
            {
                selectedweapon = transform.childCount-1;
            }
            else
            {
                selectedweapon--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            selectedweapon = 0;
        }


        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
            selectedweapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedweapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedweapon = 3;
        }

        if (previouswselect != selectedweapon) {
            currammo[previouswselect] = player.currWeaponAmmo;
            SelectWeapon();
            player.UpdateText();
        }
    }
    void SelectWeapon() {
        int i = 0;
        foreach (Transform weapon in transform) {
            if (i == selectedweapon)
            {
                weapon.gameObject.SetActive(true);
                player.spawnpoint = spawnp[i];
                player.bullet = bullet[i];
                player.guns = weapon;
                player.firerate = firerate[i];
                player.currWeaponAmmo = currammo[i];
                player.maxWeaponAmmo = maxammo[i];
            }
            else {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}

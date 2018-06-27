using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
    private int selectedweapon = 0;
    private PlayerControl player;
    public GameObject[] bullet;
    public Transform[] spawnp;
    public float[] firerate;

    //index code 0 = golf, 1= basket,etc
	void Start () {
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
                selectedweapon--        ;
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
            SelectWeapon();
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
            }
            else {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}

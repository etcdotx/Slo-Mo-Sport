using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDropManager1 : MonoBehaviour {
    public int ActivatedAmmoDrop;
    public int seed;
    [Range(5,20)]
    public float delay= 10f;


    public AmmoDrop[] AmmoDrops;

    private void Start()
    {
        Register();
        StartCoroutine(ActivateAmmoLocation());
    }

    void Register() {
        int i = 0;
        foreach (Transform ammo in transform) {
            AmmoDrops[i] = ammo.gameObject.GetComponent<AmmoDrop>();
            i++;
        }
    }

    IEnumerator ActivateAmmoLocation()
    {
        while (true)
        {
            while (ActivatedAmmoDrop < 3)
            {
                int rand = Random.Range(0, AmmoDrops.Length);
                if (!AmmoDrops[rand].AmmoActivate) {
                    AmmoDrops[rand].gameObject.SetActive(true);
                    AmmoDrops[rand].AmmoActivate = true;
                    AmmoDrops[rand].ActivateAmmoDrop();
                    ActivatedAmmoDrop++;
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }
}

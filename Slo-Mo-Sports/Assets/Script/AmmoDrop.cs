using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour {
    public int AmmoAmmount;
    public int AmmoType; //0 = basket, 1 = golf, 2 = tennis,etc
    public bool AmmoActivate = false;

    public AmmoDropManager1 AmmoManager;

    public void random() {
        AmmoAmmount = Mathf.RoundToInt(Random.Range(1,4) * 10);
    }

    public void ActivateAmmoDrop() {
        int i = 0;
        AmmoType = Random.Range(0, transform.childCount);
        foreach (Transform ammodrop in transform) {
            if (i == AmmoType)
            {
                ammodrop.gameObject.SetActive(true);
                random();
            }
            else {
                ammodrop.gameObject.SetActive(false);
            }
            i++;
        }
    }
}

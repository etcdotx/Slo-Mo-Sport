using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float slowdownfactor = 0.1f;

    private void Start()
    {
        doslowmotion();
    }

    public void doslowmotion() {
        Time.timeScale = slowdownfactor;
    }

   public void backtonormal() {
        Time.timeScale = 1f;
    }
}

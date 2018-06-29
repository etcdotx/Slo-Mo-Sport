using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int kill;
    public int killneeded;

    public PlayerControl player;
    public GameObject pause;
    public GameObject winscreen;
    public CameraFPS cam;
    public WeaponSwitch weapon;
    public Text KillScore;

    public void quits()
    {
#if UNITY_EDITOR      
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void unpause() {
        pause.SetActive(false);
        Time.timeScale = 0.1f;
        cam.enabled = true;
        weapon.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        player.enabled = true;
    }

    public void backtoscene(int index) {
        SceneManager.LoadScene(index);
    }

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void Start()
    {
        if(FindObjectOfType<PlayerControl>() != null)
        {
            player = FindObjectOfType<PlayerControl>().GetComponent<PlayerControl>();
        }
        if ( FindObjectOfType<CameraFPS>() != null)
        {

            cam = FindObjectOfType<CameraFPS>().GetComponent<CameraFPS>();
        }
        if (FindObjectOfType<WeaponSwitch>() != null)
        {
            weapon = FindObjectOfType<WeaponSwitch>().GetComponent<WeaponSwitch>();
        }
        StartCoroutine(Killtext());
      
    }

    public void Restartlevel() {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }

    public void winscreens() {
        winscreen.SetActive(true);
        Time.timeScale = 0f;
        cam.enabled = false;
        weapon.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.enabled = false;
    }

    IEnumerator Killtext() {
        while (true) {
            KillScore.text = "Kill: " + kill;
            yield return new WaitForSeconds(0.5f);
            
        }
    }

    private void Update()
    {
        if (kill == killneeded)
        {
            KillScore.text = "Kill: " + kill;
            winscreens();
        }
    }
}

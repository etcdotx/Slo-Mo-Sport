using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public float firerate = 5f;
    private float nexttimetofire = 0f;

    public Transform spawnlocation;
    public GameObject bullet;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public Transform visibletarget;
    public GameObject muzzles;

    private void Start()
    {
        StartCoroutine(findtarget(.2f));
    }

    IEnumerator findtarget(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }

    void FindVisibleTarget()
    {
        visibletarget = null;
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarge = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarge, obstacleMask))
                {
                    visibletarget = target;
                    if (Time.time >= nexttimetofire)
                    {
                        nexttimetofire = Time.time + 1f / firerate;
                        shoot();
                    }
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }


    void shoot()
    {

        Quaternion rotate = Quaternion.Euler(bullet.transform.eulerAngles.x,this.transform.eulerAngles.y, 0f);
        GameObject muzzle = Instantiate(muzzles,spawnlocation.position,rotate);
        Destroy(muzzle, 2f);
        Instantiate(bullet, spawnlocation.position,rotate);
    }
}

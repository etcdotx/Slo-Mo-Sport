using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof (FieldOfView))]
public class FieldOfViewEditor : Editor {

    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);

        Vector3 viewingAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewingAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewingAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewingAngleB * fow.viewRadius);

        Handles.color = Color.red;
        if (fow.visibletarget != null)
        {
            Handles.DrawLine(fow.transform.position, fow.visibletarget.position);
        }
    }
}

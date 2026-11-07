using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEdit : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Vector3 center = fov.ViewCenterWorld;

        Handles.color = Color.white;
        Handles.DrawWireArc(center, Vector3.up, Vector3.forward, 360, fov.Radius);

        Vector3 viewAngleLeft = DirectionFromAngle(fov.EnemyTransform.eulerAngles.y, -fov.Angle / 2);
        Vector3 viewAngleRight = DirectionFromAngle(fov.EnemyTransform.eulerAngles.y, fov.Angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(center, center + viewAngleLeft * fov.Radius);
        Handles.DrawLine(center, center + viewAngleRight * fov.Radius);

        if (fov.CanSeePlayer && fov.Player != null)
        {
            Handles.color = Color.green;
            Handles.DrawLine(center, fov.Player.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FieldOfView))]
public class FieldOfViewGizmo : MonoBehaviour
{
    private FieldOfView _fov;

    private void OnDrawGizmos()
    {
        if (_fov == null)
            _fov = GetComponent<FieldOfView>();

        if (_fov == null)
            return;

        if (!Application.isPlaying)
            _fov.CheckInEditMode();

        Vector3 center = _fov.ViewCenterWorld;
        float radius = _fov.Radius;

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(center, radius);

        float y = _fov.EnemyTransform.eulerAngles.y;
        Vector3 left = DirectionFromAngle(y, -_fov.Angle / 2);
        Vector3 right = DirectionFromAngle(y, _fov.Angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(center, center + left * radius);
        Gizmos.DrawLine(center, center + right * radius);

        if (_fov.CanSeePlayer && _fov.Player != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(center, _fov.Player.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}

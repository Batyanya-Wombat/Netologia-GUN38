using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] private Vector3 _viewCenterOffset;
    [SerializeField] private float _radius;
    [SerializeField, Range(0, 360)] private float _angle;
    [SerializeField] private Player _player;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private LayerMask _obstacleMask;

    private bool _canSeePlayer;

    public bool CanSeePlayer => _canSeePlayer;
    public float Radius => _radius;
    public float Angle => _angle;
    public Player Player => _player;

    public Transform EnemyTransform => _enemyTransform != null ? _enemyTransform : transform;

    public Vector3 ViewCenterWorld =>
        EnemyTransform.position + EnemyTransform.TransformDirection(_viewCenterOffset);

    private void Reset()
    {
        _enemyTransform = transform;
    }

    private void Start()
    {
        if (_enemyTransform == null)
            _enemyTransform = transform;

        _player = FindObjectOfType<Player>();
        StartCoroutine(FovRoutine());
    }

    public void CheckInEditMode()
    {
        if (_player == null)
            _player = FindObjectOfType<Player>();

        FieldOfViewCheck();
    }

    private IEnumerator FovRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (_player == null)
        {
            yield return wait;
        }

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        _canSeePlayer = false;

        if (_player == null)
            return;

        Vector3 viewCenter = ViewCenterWorld;

        Collider[] rangeChecks = Physics.OverlapSphere(
            viewCenter,
            _radius,
            _playerMask);

        Transform target = null;
        foreach (Collider col in rangeChecks)
        {
            if (col.transform == EnemyTransform)
                continue;

            if (col.transform == _player.transform)
            {
                target = _player.transform;
                break;
            }
        }

        if (target == null)
            return;

        Vector3 directionToTarget = (target.position - viewCenter).normalized;

        if (Vector3.Angle(EnemyTransform.forward, directionToTarget) < _angle / 2)
        {
            float distanceToTarget = Vector3.Distance(viewCenter, target.position);

            if (_obstacleMask.value == 0 ||
                !Physics.Raycast(
                    viewCenter + directionToTarget * 0.3f,
                    directionToTarget,
                    Mathf.Max(0, distanceToTarget - 0.3f),
                    _obstacleMask))
            {
                _canSeePlayer = true;
            }
        }
    }
}

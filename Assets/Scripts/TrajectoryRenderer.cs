using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _numPoints = 10;

    private Vector2 _startPosition;
    private Vector2 _velocity;
    private float _shootSpeed;

    private void Awake()
    {
        _lineRenderer.positionCount = 0;
    }

    public void InitializeTrajectory(Vector2 startPosition, Vector2 shootingDirection, float shootSpeed)
    {
        _startPosition = startPosition;
        _velocity = shootingDirection * shootSpeed;
        _shootSpeed = shootSpeed;
    }

    public void ShowTrajectory()
    {
        _lineRenderer.positionCount = _numPoints;

        for (int i = 0; i < _numPoints; i++)
        {
            float time = i / (float)(_numPoints - 1);
            Vector2 position = _startPosition + _velocity * time + Physics2D.gravity * (0.5f * time * time);
            _lineRenderer.SetPosition(i, position);
        }
    }

    public void HideTrajectory()
    {
        _lineRenderer.positionCount = 0;
    }
}

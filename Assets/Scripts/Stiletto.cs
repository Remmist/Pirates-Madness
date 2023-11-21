using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stiletto : MonoBehaviour
{
    [SerializeField] private GameObject stiletto;
    [SerializeField] private float launchForce;
    [SerializeField] private Transform shotPoint;

    [SerializeField] private GameObject point;
    private GameObject[] _points;
    [SerializeField] private int numberOfPoints;
    [SerializeField] private float spaceBetweenPoints;
    private Vector2 _direction;
    
    private Color _gizmosColor;

    private void Start()
    {
        _points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            _points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
            _points[i].SetActive(false);
        }
    }
    
    private void Update()
    {

        Vector2 stilettoPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _direction = mousePosition - stilettoPosition;
        transform.right = _direction;
        
        if (Input.GetButton("Fire2"))
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                _points[i].SetActive(true);
                _points[i].transform.position = PointPosition(i * spaceBetweenPoints);            }
        }
        
        else
        {
            for (int i = 0; i < numberOfPoints; i++)
            {
                _points[i].SetActive(false);
            }
        
            if (Input.GetButtonUp("Fire2"))
            {
                Throw();
            }
        }
        
    }

    private void Throw()
    {
        GameObject newStiletto = Instantiate(stiletto, shotPoint.position, Quaternion.identity);
        Rigidbody2D rb = newStiletto.GetComponent<Rigidbody2D>();
        rb.velocity = _direction.normalized * launchForce;
    }

    private Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (_direction.normalized * (launchForce * t)) + Physics2D.gravity * (0.5f * (t * t));
        return position;
    }

    private void OnDrawGizmos()
    {
        _gizmosColor = Color.red;
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(transform.position, .1f);
    }
}

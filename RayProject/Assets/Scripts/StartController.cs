using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class StartController : MonoBehaviour
{
    [SerializeField]private Character _character;
    [SerializeField]private float characterSpeed;
    private readonly RayHandler _rayHandler = new RayHandler();
    private Camera _camera;
    private Vector3 rayTarget;

    private void Awake()
    {
        _camera = Camera.main;

    }
    void Update()
    {
        var mousePos = Input.mousePosition;
        rayTarget = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        var dif = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * characterSpeed;
        _character.Move(dif);
        _camera.transform.position += dif * Time.deltaTime;
        _character.LookOn(rayTarget);
    }
    
    private void OnDrawGizmos()
    {
        Vector3 characterPosition =_character.transform.position;
        var rays = _rayHandler.MakeRay(characterPosition, rayTarget-characterPosition, 8).ToArray();
        foreach (var ray in rays)
        {
            Gizmos.DrawSphere(ray,0.1f);
        }

        for (int i = 0; i < rays.Count()-1; i++)
        {
            Gizmos.DrawLine(rays[i],rays[i+1]);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Tooltip("Time between each shot")]
    public float FireCooldown = 0.5f;
    [Tooltip("Player Camera")]
    public Camera PlayerCamera;

    InputHandler m_InputHandler;
    float m_LastShotTime = 0;

    void Start()
    {
        m_InputHandler = GetComponent<InputHandler>();
        m_LastShotTime = 0;
    }

    void Update()
    {
        if (m_InputHandler.GetFireInput() && CanShoot())
        {
            Shoot();
        }

    }

    bool CanShoot()
    {
        return Time.time - m_LastShotTime > FireCooldown;
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit " + hit.transform.name);
            Debug.DrawLine(PlayerCamera.transform.position, hit.point, Color.red, 5f);
        }
        m_LastShotTime = Time.time;
    }


}

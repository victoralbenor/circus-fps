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

    [Tooltip("Impact Effects")]
    public GameObject ImpactEffects;

    private InputHandler m_InputHandler;
    private float m_LastShotTime = 0;

    private void Start()
    {
        m_InputHandler = GetComponent<InputHandler>();
        m_LastShotTime = 0;
    }

    private void Update()
    {
        if (m_InputHandler.GetFireInput() && CanShoot())
        {
            Shoot();
        }

    }

    private bool CanShoot()
    {
        return Time.time - m_LastShotTime > FireCooldown;
    }

    private void Shoot()
    {
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out var hit, Mathf.Infinity))
        {
            Debug.DrawLine(PlayerCamera.transform.position, hit.point, Color.red, 5f);
            var effects = Instantiate(ImpactEffects, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(effects, 3f);

            var damageable = hit.transform.GetComponent<IDamageable>();
            damageable?.Damage();
        }
        m_LastShotTime = Time.time;
    }
}

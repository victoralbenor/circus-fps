using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LaserController : MonoBehaviour
{
    [Tooltip("How long the beam lasts")]
    public float Duration = 3f;

    [Tooltip("How long to wait before the next beam")]
    public float LaserCooldown = 10f;

    [Tooltip("How long to wait to apply hit effects again")]
    public float HitCooldown = 0.1f;

    [Tooltip("Player Camera")]
    public Camera PlayerCamera;

    private InputHandler m_InputHandler;
    private float m_LastLaserTime;
    private float m_LastHitTime;
    private bool m_LaserActive = false;
    private LineRenderer m_LineRenderer;

    private void Start()
    {
        m_InputHandler = GetComponent<InputHandler>();
        m_LineRenderer = GetComponentInChildren<LineRenderer>();
        m_LastLaserTime = Mathf.NegativeInfinity;
        m_LastHitTime = Mathf.NegativeInfinity;
    }

    private void Update()
    {
        if (m_LaserActive) 
            UpdateLaser();
        else
            if (m_InputHandler.GetAlternativeFireInput() && CanShoot())
            {
                m_LaserActive = true;
                m_LastLaserTime = Time.time;
            }
    }

    private bool CanShoot()
    {
        return Time.time - m_LastLaserTime > LaserCooldown + Duration;
    }

    private void UpdateLaser()
    {
        if (!Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out var hit, Mathf.Infinity)) return;
        m_LineRenderer.SetPosition(0, m_LineRenderer.transform.position);
        m_LineRenderer.SetPosition(1, hit.point);
        
        if (!(Time.time - m_LastHitTime > HitCooldown)) return;
        var damageable = hit.transform.GetComponent<IDamageable>();
        damageable?.Damage();
        m_LastHitTime = Time.time;

        if (!(Time.time - m_LastLaserTime > Duration)) return;
        m_LineRenderer.SetPosition(0, Vector3.zero);
        m_LineRenderer.SetPosition(1, Vector3.zero);
        m_LaserActive = false;
    }
}

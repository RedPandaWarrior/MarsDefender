using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class DerivedBase : Base
{
    protected AudioSource _audioSource = null;
    [SerializeField] protected AudioClip m_shootClip = null;
    
    [SerializeField] protected float _fireInterval = 0;
    protected float m_fireTimer = 0;

    public virtual float m_fireInterval { get => _fireInterval; set => _fireInterval = value; }
    
    protected void Fire(bool operation, Quaternion rotation, RocketPool objPool)
    {
        m_fireTimer += Time.deltaTime;
        if (m_fireTimer >= _fireInterval) {
            m_fireTimer = 0;    
            
            if (operation) {
                _audioSource.PlayOneShot(m_shootClip);

                GameObject rocket = objPool.Get();
                rocket.transform.position = this.transform.position;
                rocket.transform.rotation = rotation;
            }
        }
    }
}




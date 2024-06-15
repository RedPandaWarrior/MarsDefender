using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Bullet")]
public class Rocket : MonoBehaviour
{
    [SerializeField] protected float _speed = 10;
    [SerializeField] protected int _damage = 1;
    [SerializeField] protected string _targetTriggerTag = "Enemy";

    protected virtual float m_speed{get=>_speed;set=>_speed = value;}
    protected virtual int m_damage{get=>_damage;set=>_damage = value;}
    protected virtual string m_targetTriggerTag { get=> _targetTriggerTag; set=> _targetTriggerTag = value;}


    protected void Update()
    {
        MoveFoward();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(m_targetTriggerTag)) {
            ReleaseToPool();
        }
    }

    private void OnBecameInvisible()
    {
        if (this.gameObject.activeSelf) {
            ReleaseToPool();
        }
    }

    protected void MoveFoward()
    {
        this.transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
    }
    protected virtual void ReleaseToPool()
    {
        RocketPool.Instance.Release(this.gameObject);
    }

    

}

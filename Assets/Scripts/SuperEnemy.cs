using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[AddComponentMenu("MyGame/SuperEnemy")]
public class SuperEnemy : DerivedBase
{
    private MeshRenderer _subMeshRenderer;

    private void Awake()
    {
        _audioSource = this.AddComponent<AudioSource>();
        _subMeshRenderer = this.transform.Find("enemy2").GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        Move();
        AutoFire();
    }

    private void AutoFire()
    {
        if (Player.Instance) {
            Vector3 relativePos = Player.Instance.transform.position - this.transform.position;
            Fire(operation: true, Quaternion.LookRotation(relativePos), EnemyRocketPool.Instance);
        }
    }
    private void Move()
    {
        if (_subMeshRenderer.isVisible == false && this.gameObject.activeSelf) {
            Destroy(this.gameObject);
        }

        this.transform.position -= Vector3.forward * m_speed * Time.deltaTime;
    }


}
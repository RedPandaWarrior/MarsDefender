using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[AddComponentMenu("MyGame/Player")]
public class Player : DerivedBase
{
    public static Player Instance;

    private void Awake()
    {
        Instance = this;
        _audioSource = this.AddComponent<AudioSource>();
    }
    private void Update()
    {
        Move();
        PressKeyToFire();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyRocket") || other.CompareTag("Enemy")) {
            m_life -= 1;
            GameManager.Instance.ChangeLife(m_life);
            ExplodeWhenDied();
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 newPos = this.transform.position +
                         new Vector3(x, 0, z) * m_speed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, -8.5f, 9f);
        newPos.z = Mathf.Clamp(newPos.z, -7f, 4f);
        this.transform.position = newPos;
    }
    private void PressKeyToFire()
    {
        bool operation = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
        Fire(operation, Quaternion.identity, RocketPool.Instance);
    }


}

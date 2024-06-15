using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Base
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        Move();
    }

    protected void Move()
    {
        if (_meshRenderer.isVisible == false && this.gameObject.activeSelf) {
            Destroy(this.gameObject);
        }

        float x = Mathf.Sin(Time.time) * m_speed * Time.deltaTime;
        float z = m_speed * Time.deltaTime;
        this.transform.position -= new Vector3(x, 0, z);
    }

}

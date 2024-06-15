using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{

    [SerializeField] protected GameObject[] m_enemies = null;
    [SerializeField] protected float m_timeSpan = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) {
            yield return new WaitForSeconds(m_timeSpan);

            int i = Random.Range(0, m_enemies.Length);
            Instantiate(m_enemies[i], this.transform.position, m_enemies[i].transform.rotation);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(this.transform.position, "item.png");
    }


}

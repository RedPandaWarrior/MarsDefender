using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : Rocket
{

    protected override void ReleaseToPool()
    {
        EnemyRocketPool.Instance.Release(this.gameObject);
    }

}

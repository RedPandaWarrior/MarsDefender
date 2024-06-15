using UnityEngine;
using UnityEngine.Pool;

[AddComponentMenu("MyGame/EnemyRocketPool")]
public class EnemyRocketPool : RocketPool
{
    public static new EnemyRocketPool Instance = null;

    protected override void Awake()
    {
        if (Instance == null) {
            Instance = this;    
            m_pool = new ObjectPool<GameObject>(CreateFunc, TakeFromPool, ReturnToPool);
        } else {
            Debug.LogError("Multiple EnemyRocketPool instances detected!");
            Destroy(gameObject);
        }
    }
}

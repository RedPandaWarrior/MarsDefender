using UnityEngine;
using UnityEngine.Pool;

[AddComponentMenu("MyGame/RocketPool")]
public class RocketPool : MonoBehaviour
{
    public static RocketPool Instance = null;

    [SerializeField] protected ObjectPool<GameObject> m_pool = null;
    [SerializeField] protected GameObject m_obj = null;
    
    [SerializeField] protected int m_countAll = 0;
    [SerializeField] protected int m_coutActive = 0;

    protected virtual void Awake()
    {
        if (Instance == null) {
            Instance = this;
            m_pool = new ObjectPool<GameObject>(CreateFunc, TakeFromPool, ReturnToPool);
            if (m_pool == null) {
                Debug.LogError($"{this.gameObject} pool not been build");
                return;
            }
        } else {
            Debug.LogError("Multiple RocketPool instances detected!");
            Destroy(gameObject);
        }
    }

    protected void Update()
    {
        m_countAll = m_pool.CountAll;
        m_coutActive = m_pool.CountActive;
    }

    protected virtual GameObject CreateFunc()
    {
        return Instantiate(m_obj);
    }

    protected void TakeFromPool(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    protected void ReturnToPool(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    public GameObject Get()
    {
        return m_pool.Get();
    }

    public void Release(GameObject obj)
    {
        m_pool.Release(obj);
    }
}

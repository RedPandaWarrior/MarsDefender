using UnityEngine;


public class Base : MonoBehaviour
{
    [SerializeField] protected GameObject m_explosionFX = null;
    // 提高封装性
    [SerializeField] protected int _life = 0;
    [SerializeField] protected float _speed = 0;
    [SerializeField] protected int _point = 0;

    public virtual int m_life { get => _life; set => _life = value; }
    protected virtual float m_speed { get => _speed; set => _speed = value; }
    protected virtual int m_point { get => _point; set => _point = value; }
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rocket")) {
            _life -= 1;
            ExplodeWhenDied();
        } else if (other.CompareTag("Player")) {
            _life = 0;
            ExplodeWhenDied();
        }
    }
    
    protected void ExplodeWhenDied(){
        if (_life <= 0) {
            Instantiate(m_explosionFX, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            GameManager.Instance.ChangeScore(_point);

        }
    }
}







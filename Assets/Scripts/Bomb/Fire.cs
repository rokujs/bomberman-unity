using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Character>())
        {
            other.GetComponent<Character>().DoDamage(damage);
        }
    }
    public void finish()
    {
        Destroy(gameObject);
    }
}

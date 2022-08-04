using UnityEngine;

public class Fragile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Fire>())
        {
            Destroy(gameObject);
        }
    }
}

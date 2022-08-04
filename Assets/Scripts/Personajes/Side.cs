using UnityEngine;
using UnityEngine.AI;

public class Side : MonoBehaviour
{
    public void AsignarBando(Side player, bool bando)
    {
        if (bando)
        {
            Destroy(player.GetComponent<Enemy>());
            Destroy(player.GetComponent<NavMeshAgent>());
        }
        else
        {
            Destroy(player.GetComponent<Player>());
            player.name = "Enemy";
        }
    }
}

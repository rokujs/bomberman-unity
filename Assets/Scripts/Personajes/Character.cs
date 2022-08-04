using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Movimiento))]
[RequireComponent(typeof(Bomb))]
public abstract class Character : MonoBehaviour
{

    [SerializeField] protected int health = 3;
    [SerializeField] protected Movimiento movimiento;
    [SerializeField] protected Animator animation;
    [SerializeField] protected Bomb bomb;
    [SerializeField] protected int magnitudBomb = 1;
    [SerializeField] protected int side;
    [SerializeField] protected float timeBomb;
    [SerializeField] protected bool putBombPlayer = false;
    [SerializeField] protected string horizontal, vertical, salto;
    [SerializeField] protected Image[] imagenes = new Image[3];

    public abstract void DoDamage(int amount);

    public abstract void Die();

    public void PutBomb(Vector3 location)
    {
        Vector3 locationBomb = new Vector3(location.x, 0.5f, location.z);
        Instantiate(bomb, locationBomb, Quaternion.identity);
    }

    public void SetHealth(int health)
    {
        this.health = health;
        if (this.health < 0) this.health = 0;
    }
}

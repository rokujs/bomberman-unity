using UnityEngine;
// using PaqueteInventario;

public class Player : Character
{
    [SerializeField] public int id;
    private Vector3 mov;
    void Start()
    {
        gameObject.tag = "Player";
        movimiento = GetComponent<Movimiento>();
        animation = GetComponent<Animator>();
    }

    public void AsignarPlayer(int id, string vertical, string horizontal, string salto, Material textura)
    {
        this.id = id;
        gameObject.name = "Player " + this.id;
        this.salto = salto;
        this.vertical = vertical;
        this.horizontal = horizontal;
        // transform.GetComponentsInChildren<MeshRenderer>()[0].material = textura;
        // transform.GetComponentsInChildren<MeshRenderer>()[1].material = textura;
    }
    public void AsignarPlayer(int id, Material textura)
    {
        this.id = id;
        gameObject.name = "Player";
        this.salto = "Jump1";
        this.vertical = "Vertical1";
        this.horizontal = "Horizontal1";
        // transform.GetComponentsInChildren<MeshRenderer>()[0].material = textura;
        // transform.GetComponentsInChildren<MeshRenderer>()[1].material = textura;
    }

    private void Update()
    {
        mov = new Vector3(Input.GetAxis(horizontal), 0f, Input.GetAxis(vertical));
        if (Input.GetAxis(horizontal) != 0) movimiento.MovHorizontal(mov, animation);
        if (Input.GetAxis(vertical) != 0) movimiento.MovVertical(mov, animation);
        if (Input.GetButtonDown(salto) && !putBombPlayer)
        {
            putBombPlayer = true;
            PutBomb(gameObject.transform.position);
        }

        if (putBombPlayer)
        {
            timeBomb += Time.deltaTime;
            if (timeBomb > 4f)
            {
                putBombPlayer = false;
                timeBomb = 0f;
            }
        }

        this.side = GameObject.FindGameObjectsWithTag("Player").Length;
        if (this.side == 1) win();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Bomb>())
        {
            other.GetComponent<Collider>().isTrigger = false;
        }
    }
    public override void Die()
    {
        GameObject.FindWithTag("LevelGameManager")
                    .GetComponent<LevelGameManager>()
                    .DoGameOverDefeat();
    }
    public void win()
    {
        GameObject.FindWithTag("LevelGameManager")
                    .GetComponent<LevelGameManager>()
                    .DoGameOverWin();
    }

    public override void DoDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        Destroy(imagenes[health]);
    }
}

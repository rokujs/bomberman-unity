using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private int currentTarget;
    [SerializeField] private int score = 10;
    [SerializeField] private bool alive = true;
    [SerializeField] private bool bombPut = true;
    [SerializeField] private float bombTime;

    [SerializeField] GameObject[] players;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject[] targets;
    [SerializeField] GameObject[] fragiles;

    private void Start()
    {
        bombPut = false;

        movimiento = GetComponent<Movimiento>();
        animation = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        targets = GameObject.FindGameObjectsWithTag("Target");
        currentTarget = NextTarget();
        players = GameObject.FindGameObjectsWithTag("Player");
        fragiles = GameObject.FindGameObjectsWithTag("Fragile");
    }

    public override void Die()
    {
        Destroy(gameObject);
        alive = false;
    }

    public override void DoDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            if (alive) Die();
        }
        Destroy(imagenes[health]);
    }
    void detectBomb()
    {

    }

    void detectFragile()
    {
        foreach (GameObject fragile in fragiles)
        {
            fragiles = GameObject.FindGameObjectsWithTag("Fragile");
            try
            {
                if (Vector3.Distance(transform.position, fragile.transform.position) < 1f)
                {
                    PutBomb(transform.position);
                    bombTime = 0f;
                    bombPut = true;
                    break;
                }
            }
            catch
            {
                fragiles = GameObject.FindGameObjectsWithTag("Fragile");
            }
        }
    }

    void BuscarPlayer()
    {
        try
        {
            foreach (GameObject player in players)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < 2f && player != gameObject)
                {
                    PutBomb(transform.position);
                    bombTime = 0f;
                    bombPut = true;
                    break;
                }
            }
        }
        catch
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }
    }
    private void NextPositionTarget()
    {
        if (Vector3.Distance(transform.position, targets[currentTarget].transform.position) < 2f)
        {
            currentTarget = NextTarget();
        }
        else
        {
            agent.SetDestination(targets[currentTarget].transform.position);
            animation.SetFloat("Walk", agent.acceleration);
        }
    }
    private int NextTarget()
    {
        int target = Random.Range(0, targets.Length);
        return target;
    }
    private void Update()
    {
        if (!bombPut)
        {
            BuscarPlayer();
            detectFragile();
        }
        else
        {
            bombTime += Time.deltaTime;
            if (bombTime > 5f) bombPut = false;
        }
        NextPositionTarget();
    }
}
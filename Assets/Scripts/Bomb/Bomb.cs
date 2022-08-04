using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] int magnitudExplocion = 1;
    private float stopwatchBomb;
    private Vector3[] positionFire;
    private bool activeBomb;
    public Fire fire;
    [SerializeField] GameObject[] walls;
    [SerializeField] Fire[,] activeFire;
    [SerializeField] Fire firstActiveFire;
    private void Start()
    {

        magnitudExplocion = 2;
        activeBomb = true;

        positionFire = new Vector3[5];
        activeFire = new Fire[4, magnitudExplocion];
        walls = GameObject.FindGameObjectsWithTag("Wall");

        for (int i = 0; i < 5; i++)
        {
            positionFire[i] = gameObject.transform.position;
        }
    }
    void Update()
    {
        if (activeBomb && stopwatchBomb > 2f)
        {
            firstActiveFire = Instantiate(fire, positionFire[0], Quaternion.identity);
            gameObject.GetComponent<Collider>().isTrigger = true;

            for (int i = 1; i <= magnitudExplocion; i++)
            {
                positionFire[1].x = positionFire[0].x + i;
                positionFire[2].x = positionFire[0].x - i;
                positionFire[3].z = positionFire[0].z + i;
                positionFire[4].z = positionFire[0].z - i;
                for (int j = 1; j < 5; j++)
                {
                    foreach (GameObject wall in walls)
                    {
                        if (Vector3.Distance(positionFire[j], wall.transform.position) < 0.6)
                        {
                            positionFire[j].y = 15;
                            break;
                        }
                    }
                    activeFire[j - 1, i - 1] = Instantiate(fire, positionFire[j], Quaternion.identity);
                }
                activeBomb = false;
            }
            stopwatchBomb = 0;
        }
        if (!activeBomb && stopwatchBomb > 2f)
        {
            firstActiveFire.finish();

            for (int i = 0; i < magnitudExplocion; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    activeFire[j, i].finish();
                }
            }
            Destroy(gameObject);
        }
        stopwatchBomb += Time.deltaTime;
    }
}

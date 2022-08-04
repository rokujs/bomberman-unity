using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] GameObject wallSelect;
    [SerializeField] Vector3 position;
    [SerializeField] int numWall;

    private void Start()
    {
        numWall = 0;

        for (int i = -10; i <= 10; i++)
        {
            for (int r = -5; r <= 5; r++)
            {
                position = new Vector3(i, 0, r);
                wallSelect = Instantiate(wall, position, Quaternion.identity);
                wallSelect.name = "Wall " + numWall;
                numWall++;
            }
        }
    }
}

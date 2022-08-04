using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGameManager : MonoBehaviour
{

    [SerializeField] private int score = 0;
    [SerializeField] public int numPlayers = 1;
    [SerializeField] Side[] player = new Side[4];
    public Material[] mat = new Material[4];
    [SerializeField] public int pts1 = 0, pts2 = 0;
    [SerializeField] int side;

    private void Start()
    {
        gameObject.tag = "LevelGameManager";
        side = GameObject.FindGameObjectsWithTag("Player").Length;
        numPlayers = 2;
        for (int i = 0; i < 4; i++)
        {
            int newNumber = i + 1;
            if (numPlayers == 1 && i < 1)
            {
                player[i].AsignarBando(player[i], true);
                player[i].GetComponent<Player>().AsignarPlayer(newNumber, mat[i]);
            }
            else if (numPlayers == 2 && i < 2)
            {
                player[i].AsignarBando(player[i], true);
                player[i].GetComponent<Player>().AsignarPlayer(newNumber, "Vertical" + newNumber, "Horizontal" + newNumber, "Jump" + newNumber, mat[i]);
            }
            else
            {
                player[i].AsignarBando(player[i], false);
            }
        }
    }

    public void DoGameOverDefeat()
    {
        SceneManager.LoadScene("Defeat");
    }
    public void DoGameOverWin()
    {
        SceneManager.LoadScene("Win");
    }
}

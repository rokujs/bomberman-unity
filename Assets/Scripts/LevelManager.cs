using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animation;
    [SerializeField] bool endGame = false;
    [SerializeField] bool actionAnimation = false;
    [SerializeField] float timeAnimation = 0;

    private void Start()
    {
        endGame = false;
        actionAnimation = false;
        timeAnimation = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (this.name)
            {
                case "nieve":
                    SceneManager.LoadScene("Nieve");
                    break;
                case "tierra":
                    SceneManager.LoadScene("Tierra");
                    break;
                case "win":
                    gameOver(true);
                    break;
                case "defeat":
                    gameOver(false);
                    break;
            }
        }
    }

    private void gameOver(bool win)
    {
        if (win)
        {
            animation.SetBool("Victory", true);
        }
        else
        {
            animation.SetBool("defeat", true);
        }
        actionAnimation = true;
        endGame = true;
    }

    private void Update()
    {
        if (endGame)
        {
            if (timeAnimation > 0.1f)
            {
                if (actionAnimation)
                {
                    animation.SetBool("Victory", false);
                    animation.SetBool("defeat", false);
                    actionAnimation = false;
                }
            }
            timeAnimation += Time.deltaTime;
            if (timeAnimation > 5f) SceneManager.LoadScene("Menu_inicio");
        }
    }
}

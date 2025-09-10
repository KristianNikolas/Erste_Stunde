using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public string state = ""; //Title, paused, cutscene, loading

    public int score;

    public WizardStats stats;

    public static GameObject gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = gameObject;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }

    float count = 0;

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 10)
        {
            count = 0;
            SceneManager.LoadScene("Title");
        }
    }
}

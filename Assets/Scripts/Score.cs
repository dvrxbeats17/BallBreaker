using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] private float gameSpeed;
    [SerializeField] private SceneLoader sceneLoader;

    [SerializeField] private int currentScore;
    [SerializeField] private int pointsPerBlockDestroyd;
    [SerializeField] public TMP_Text scoreText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Score>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {  
        scoreText.text = currentScore.ToString();
    }
    private void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyd;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}

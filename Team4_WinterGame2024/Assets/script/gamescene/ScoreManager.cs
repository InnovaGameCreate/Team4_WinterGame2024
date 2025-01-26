using UnityEngine;
using UnityEngine.UI;  // Text を使用するために必要
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;  
    [SerializeField] public int E1score;
    [SerializeField] public int E2score;
    [SerializeField] public int E1damege;
    [SerializeField] public int E2damege;

    public Text scoreText;  

    void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
    
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "Start")
        {
            score = 0;
            UpdateScoreDisplay();
        }
    }

    public void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}

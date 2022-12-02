using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour,IGameState
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreTM;

    public void Init()
    {
        score = 0;
    }

    public void TitleState()
    {
        Init();
    }

    public void PlayState()
    {
        Init();
    }

    public void GameOverState()
    {
        
    }

    private void Awake()
    {
        if (scoreTM == null)
        {
            scoreTM = GetComponent<TextMeshProUGUI>();
        }
    }

    void Start()
    {
        score = 0;
    }

    public void AddScore(int scoreInt)
    {
        score += scoreInt;
        scoreTM.text = score.ToString();
    }
}

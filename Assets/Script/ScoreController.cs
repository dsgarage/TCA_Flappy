using UnityEngine;

public class ScoreController : MonoBehaviour,IGameState
{
    [SerializeField] private Score score;
    [SerializeField] private int _scoreVar = 1;

    public void ScoreReference(Score reference)
    {
        score = reference;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score.AddScore(_scoreVar);
        }
    }

    public void Init()
    {
        throw new System.NotImplementedException();
    }

    public void TitleState()
    {
        throw new System.NotImplementedException();
    }

    public void PlayState()
    {
        throw new System.NotImplementedException();
    }

    public void GameOverState()
    {
        throw new System.NotImplementedException();
    }
}

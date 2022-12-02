using UnityEngine;
public class PlayerState : MonoBehaviour,IGameState
{
    [SerializeField] private bool dead = false;
    private void Awake()
    {

        Init();
    }
    public void Init() { dead = false; }
    public bool DeadOrAlive() { return dead; }
    public void TitleState() { Init(); }
    public void PlayState()
    {
        
    }

    public void GameOverState() { }

    public bool GetState()
    {
        return dead;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boad")
        {
            dead = true;
        }
    }
}

using System;
using UnityEngine;
public class PlayerState : MonoBehaviour,IGameState
{
    [SerializeField] private bool dead = false;
    [SerializeField] private Jump playerJump;
    
    private void Awake()
    {
        playerJump = GetComponent<Jump>();
        Init();
    }
    public void Init() { dead = false; }
    public bool DeadOrAlive() { return dead; }
    
    public void TitleState() { Init(); }
    public void PlayState()
    {
        
    }

    public bool GetStay()
    {
        return playerJump.Stay;
    }

    public void GameOverState() { }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boad")
        {
            dead = true;
        }
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public enum GameState
    {
        Title = 0,
        Play,
        GameOver
    }
    
    [SerializeField] private PlayerState _playerState;
    [SerializeField] private GameState _gameState = GameState.Title;
    [SerializeField] private bool restart = false;

    private IGameState[] _iGameState;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _iGameState = GameObjectExtensions.FindObjectsOfInterface<IGameState>();
        Debug.Log("IGameState:" + _iGameState.Length);
    }

    private void FixedUpdate()
    {
        if (_playerState.DeadOrAlive())
        {
            _gameState = GameState.GameOver;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
        switch (_gameState)
        {
            case GameState.Title:
                //鳥を出しっぱなしで落ちないようにする
                //タイトルUIを出す

                foreach(IGameState gs in _iGameState ) 
                { 
                    gs.TitleState(); 
                }
                
                break;
            case GameState.Play:
                if (_gameState != GameState.Play)
                {
                    restart = true;
                }
                //最初の状態は、Rigidbodyがきかないように
                //最初にタップしたところからボードがでてゲームスタート
                if (restart)
                {
                    foreach(IGameState gs in _iGameState ) 
                    { 
                        gs.PlayState(); 
                    }

                    restart = false;
                }
                break;
            case GameState.GameOver:
                //リザルト画面を出す
                //GameState .Playに戻す
                foreach(IGameState gs in _iGameState ) 
                { 
                    gs.GameOverState(); 
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }

    public void SetGameState(GameState gamestate)
    {
        _gameState = gamestate;
    }

    public void SetGameState(int gamestateNo)
    {
        _gameState = (GameState)Enum.ToObject(typeof(GameState), gamestateNo);
    }


}

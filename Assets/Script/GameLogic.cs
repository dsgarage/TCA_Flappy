using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public enum GameState
    {
        Title,
        Play,
        GameOver
    }
    
    [SerializeField] private PlayerState _playerState;
    [SerializeField] private GameState _gameState = GameState.Title;

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
                
                break;
            case GameState.Play:
                //最初の状態は、Rigidbodyがきかないように
                //最初にタップしたところからボードがでてゲームスタート
                break;
            case GameState.GameOver:
                //リザルト画面を出す
                //GameState .Playに戻す
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }


}

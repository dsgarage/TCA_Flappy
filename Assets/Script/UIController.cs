using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour,IGameState
{
    [SerializeField] private Transform title;
    [SerializeField] private Transform score;
    [SerializeField] private Transform result;

    public void Init()
    {
        
    }

    public void TitleState()
    {
        title.gameObject.SetActive(true);
        score.gameObject.SetActive(false);
        result.gameObject.SetActive(false);
    }

    public void PlayState()
    {
        title.gameObject.SetActive(false);
        score.gameObject.SetActive(true);
        result.gameObject.SetActive(false);
    }

    public void GameOverState()
    {
        title.gameObject.SetActive(false);
        score.gameObject.SetActive(false);
        result.gameObject.SetActive(true);
    }
}

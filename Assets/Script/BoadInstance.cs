using UnityEngine;
using Random = UnityEngine.Random;
public class BoadInstance : MonoBehaviour,IGameState
{
    [SerializeField] private Score score;
    [SerializeField] GameObject boadObject;
    [SerializeField] private bool instantiate = false;
    [SerializeField]readonly float interval = 2;
    float _nextSpawnTime = 0;
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            instantiate = true;
        }
        if (instantiate)
        {
            if( _nextSpawnTime < Time.timeSinceLevelLoad)
            {
                _nextSpawnTime = Time.timeSinceLevelLoad + interval;
                LocalInstantate();
            }
        }
    }

    public void Init() { instantiate = false; }
    public void TitleState() { Init(); }
    public void PlayState() { instantiate = false; }
    public void GameOverState() { instantiate = false;}
    
    void LocalInstantate ()
    {
        // オブジェクトの生成して子オブジェクトに登録
        GameObject obj = (GameObject)GameObject.Instantiate(boadObject) ;
        obj.transform.parent = transform;
        var ControllerReference = obj.GetComponent<ScoreController>();
        ControllerReference.ScoreReference(score);
        
        // 座標を設定.
        float y = Random.Range (3f, 10f);
        obj.transform.localPosition = new Vector3(0, y, 0);
    }

    void BoadStay()
    {
        instantiate = false;
    }
}

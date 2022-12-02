using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour,IGameState
{
    [SerializeField] private bool stay;
    public bool Stay
    {
        get { return stay; }
    }
    
    [SerializeField] private bool gameOver = false;
    private bool _isJumpRequest;
    public float power = 2;
    [SerializeField] private Transform _titlePosition;

    private Rigidbody2D _rigidbody2D;
    private float initGravidyScale;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _titlePosition = transform;
        initGravidyScale = _rigidbody2D.gravityScale;
    }

    void Start()
    {
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        gameOver = false;
        PlayerStay();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            stay = false;
            _rigidbody2D.gravityScale = initGravidyScale;
        }
        
        if (!gameOver&& !stay)
        {
            if( Input.GetMouseButtonDown (0) ){
                _isJumpRequest = true;
            }
        }
    }

    private void PlayerStay()
    {
        stay = true;
        _rigidbody2D.gravityScale = 0;
    }

    public void Init()
    {
        _rigidbody2D.gravityScale = 0;
        gameOver = false;
        transform.position = _titlePosition.position;
        PlayerStay();
    }

    public void TitleState()
    {
        
    }

    public void PlayState()
    {
        Init();
        gameOver = false;
    }
    
    public void GameOverState()
    {
        gameOver = true;
    }

    void FixedUpdate ()
    {
        if (_isJumpRequest) {
            _isJumpRequest = false;
            _rigidbody2D.velocity = Vector3.up * power;
        }
    }


}

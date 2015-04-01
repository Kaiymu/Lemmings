using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Lemmings : MonoBehaviour {

	[Range(0.1f, 10f)]
    public float moveSpeed = 5f;
	[Range(0.1f, 10f)]
	public float jumpSpeed = 5f;
    [Range(0.1f, 10f)]
    public float jumpHeight = 5f;
   
	[HideInInspector]
	public Renderer rendererLemmings;

    [HideInInspector]
    public Rigidbody2D m_rigidbody2D;

	public FSM<Lemmings> fsm;

    public EnumLemmings enumLemmings;
	public string lemmingColor;

    [HideInInspector]
    public Animator animatorLemmings;
    private bool facingRight;

    [HideInInspector]
    public Transform m_transform;

    [HideInInspector]
    public bool isClicked = false;

    [HideInInspector]
    public GameObject m_Lemming;

	[Range(0.1f, 10f)]
	public float distanceDeathFall;
	public float timerToDeathFall = 5f;
	
	private float maxTimer;
	[HideInInspector]
	public bool activateLove;
	private bool canDieFromFall = true;


    private GameObject[] triggersToSpawn = new GameObject[6];

    private void LoadLemmings() { 
        triggersToSpawn[0] = Resources.Load("Prefabs/Triggers/OnMap/LemmingsCreatePlatform") as GameObject;
        triggersToSpawn[1] = Resources.Load("Prefabs/Triggers/OnMap/LemmingsTriggerGravity") as GameObject;
		triggersToSpawn[2] = Resources.Load("Prefabs/Triggers/OnMap/LemmingsTriggerPoisoned") as GameObject;
        triggersToSpawn[3] = Resources.Load("Prefabs/Triggers/OnLemmings/LemmingsTriggerStone") as GameObject;
        triggersToSpawn[4] = Resources.Load("Prefabs/Triggers/OnLemmings/LemmingsTriggerBouncer") as GameObject;
        triggersToSpawn[5] = Resources.Load("Prefabs/Triggers/OnLemmings/LemmingsTriggerLove") as GameObject;
    }
    private Vector2 currentY;

    private void Awake()
    {
        rendererLemmings = GetComponent<Renderer>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        animatorLemmings = GetComponent<Animator>();
        m_Lemming = gameObject;
        m_transform = GetComponent<Transform>();
        currentY = m_transform.position;
    }

    private void Start()
    {
		fsm = new FSM<Lemmings>();
        if(GameManager.instance.isPaused)
            fsm.Configure(this, PauseState.Instance);
        else 
            fsm.Configure(this, MovingState.Instance);
        LoadLemmings();
    }

    private float ancientY;

    private void Update() {

		if(activateLove)
			InLove();

		if(canDieFromFall)
			DeathByFall();
    }

	private void DeathByFall() { 
		if(IsFalling()) {
			ancientY = Vector2.Distance(m_transform.position, currentY);
		}
		else {
			if(ancientY > distanceDeathFall) {
				fsm.ChangeState(DeadFallState.Instance);
			}
			currentY = m_transform.position;
		}
	}

	private void InLove() {
		maxTimer += Time.deltaTime;

		if(maxTimer < timerToDeathFall) {
			canDieFromFall = false;
		}
		else {
			activateLove = false;
			canDieFromFall = true;
		}
	}

    public void LemmingsDeath() {
        LemmingsManager.instance.RemoveLemming(gameObject);
    }

    public void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public bool IsFalling() {
        if(IsOnGround()) {
            return false;
        }
        else {
            if(m_rigidbody2D.velocity.y < 0)
                return true;
            else 
                return false;
            }
    }

    public bool IsOnGround() {
        if(m_rigidbody2D.velocity.y == 0)
            return true;
        else 
            return false;
    }

    public void AnimatorList() {
        switch(enumLemmings)
        {
            case EnumLemmings.PLATFORM : 
                Instantiate(triggersToSpawn[0], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
                LemmingsManager.instance.RemoveLemming(gameObject);
            break;
			case EnumLemmings.GRAVITY : 
				Instantiate(triggersToSpawn[1], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
				LemmingsManager.instance.RemoveLemming(gameObject);
			break;
			case EnumLemmings.POISON : 
				Instantiate(triggersToSpawn[2], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
				LemmingsManager.instance.RemoveLemming(gameObject);
			break;
            case EnumLemmings.STONE : 
                Instantiate(triggersToSpawn[3], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
                LemmingsManager.instance.RemoveLemming(gameObject);
           break;

            case EnumLemmings.BOUNCE : 
                Instantiate(triggersToSpawn[4], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
                LemmingsManager.instance.RemoveLemming(gameObject);
                break;
            case EnumLemmings.LOVE : 
                Instantiate(triggersToSpawn[5], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
                LemmingsManager.instance.RemoveLemming(gameObject);
                break;
		}
		
		isClicked = false;
    }
}

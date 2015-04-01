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

    private GameObject[] triggersToSpawn = new GameObject[3];

    private void LoadLemmings() { 
		triggersToSpawn[0] = Resources.Load("Prefabs/Triggers/OnLemmings/LemmingsTriggerBouncer") as GameObject;
		triggersToSpawn[1] = Resources.Load("Prefabs/Triggers/OnLemmings/LemmingsTriggerStone") as GameObject;
		triggersToSpawn[2] = Resources.Load("Prefabs/Triggers/OnMap/LemmingsTriggerPoisoned") as GameObject;
    }

    private void Awake()
    {
        rendererLemmings = GetComponent<Renderer>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        animatorLemmings = GetComponent<Animator>();
        m_Lemming = gameObject;
    }

    private void Start()
    {
		fsm = new FSM<Lemmings>();
        fsm.Configure(this, MovingState.Instance);
        LoadLemmings();
    }

    public void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public bool IsFalling() {
        if(m_rigidbody2D.velocity.y < 0)
            return true;
        else 
            return false;
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
            case EnumLemmings.BOUNCE : 
                Instantiate(triggersToSpawn[0], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
                LemmingsManager.instance.RemoveLemming(gameObject);
            break;
			case EnumLemmings.STONE : 
				Instantiate(triggersToSpawn[1], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
				LemmingsManager.instance.RemoveLemming(gameObject);
			break;
			case EnumLemmings.POISON : 
				Instantiate(triggersToSpawn[2], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
				LemmingsManager.instance.RemoveLemming(gameObject);
			break;
		}
		
		isClicked = false;
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Lemmings : MonoBehaviour {

	[Range(0.1f, 10f)]
    public float moveSpeed = 5f;
	[Range(0.1f, 10f)]
	public float jumpSpeed = 5f;
   
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

    private GameObject[] triggersToSpawn = new GameObject[1];

    private void LoadLemmings() { 
        triggersToSpawn[0] = Resources.Load("Prefabs/Triggers/BouncerTrigger") as GameObject;
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
            case EnumLemmings.NEUTRAL : 
            break;
            case EnumLemmings.BOUNCE : 
                Instantiate(triggersToSpawn[0], new Vector2(transform.position.x, transform.position.y + 0.1f), transform.rotation);
                LemmingsManager.instance.RemoveLemmings(gameObject);
            break;
        }

        isClicked = false;
    }
}

using UnityEngine;
using System.Collections;

public class Lemmings : MonoBehaviour {

    public float moveSpeed = 5;
   
	[HideInInspector]
	public Renderer rendererLemmings;

    [HideInInspector]
    public Rigidbody2D m_rigidbody2D;

	private FSM<Lemmings> fsm;

    public EnumLemmings enumLemmings;

    private void Awake()
    {
        rendererLemmings = GetComponent<Renderer>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
		fsm = new FSM<Lemmings>();
        fsm.Configure(this, MovingState.Instance);
        rendererLemmings.material.color = Color.green;
    }
}

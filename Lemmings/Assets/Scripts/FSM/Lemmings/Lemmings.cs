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

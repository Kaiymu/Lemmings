using UnityEngine;
using System.Collections;

public class Lemmings : MonoBehaviour {

    public float bagSize = 10;
    public float bag = 0;
    public float miningSpeed = 5;
    public float moveSpeed = 5;
    public float emptySpeed = 10;

    [HideInInspector]
    public Transform home;
    [HideInInspector]
    public Transform mine;
	[HideInInspector]
	public Renderer rendererLemmings;

	private FSM<Lemmings> fsm;

    private void Awake()
    {
        home = GameObject.FindGameObjectWithTag("Home").transform;
        mine = GameObject.FindGameObjectWithTag("Mine").transform   ;
        rendererLemmings = GetComponent<Renderer>();
    }

    private void Start()
    {
		fsm = new FSM<Lemmings>();
        fsm.Configure(this, EmptyState.Instance);
        rendererLemmings.material.color = Color.green;
    }
}

using UnityEngine;
using System.Collections;

public class LemmingsTriggerCreatePlatform : LemmingsTriggers {

    private Rigidbody2D m_rigidbody2D;

    public float jumpSpeed;
    public float jumpHeight;

    private void Start() {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        m_rigidbody2D.velocity = new Vector2(jumpSpeed, jumpHeight);
    }

    private void DestroyLemmings() {
        Destroy(gameObject);
    }
}

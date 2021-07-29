using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigController : MonoBehaviour
{
    private Rigidbody2D m_rg;

    public GameObject name;

    public float MoveSpeed;

    public LayerMask Ground;

    public Collider2D collider2D;


    void Start()
    {

        m_rg = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        if(facedirection!=0){
            transform.localScale = new Vector3(-facedirection,1,1);
        }
        if (horizontalmove!=0)
        {
            m_rg.velocity = new Vector2(horizontalmove*MoveSpeed, m_rg.velocity.y);
        }

        if (Input.GetButtonDown("Jump")&&collider2D.IsTouchingLayers(Ground))
        {
            m_rg.velocity = new Vector2(m_rg.velocity.x, MoveSpeed);
        }

        name.transform.localPosition = new Vector2(m_rg.transform.localPosition.x - 0.73f, m_rg.transform.localPosition.y + 0.91f);
    }
}

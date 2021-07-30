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
	private float inputHorizontal;
	private float inputVertical;

    void Start()
    {

        m_rg = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    void move(){
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        if(facedirection!=0){
            transform.localScale = new Vector3(-facedirection,1,1);
        }
        if (horizontalmove!=0)
        {
            m_rg.velocity = new Vector2(horizontalmove*MoveSpeed, m_rg.velocity.y);
        }
        inputHorizontal = SimpleInput.GetAxis("Horizontal");
        inputVertical = SimpleInput.GetAxis("Vertical");
        if(inputHorizontal!=0){
            m_rg.velocity = new Vector2(inputHorizontal*MoveSpeed, m_rg.velocity.y);
            if(inputHorizontal>0){
                transform.localScale = new Vector3(-1,1,1);
            }else{
                transform.localScale = new Vector3(1,1,1);
            }
        }
        if(inputVertical!=0){

        }
        name.transform.localPosition = new Vector2(m_rg.transform.localPosition.x - 0.16f, m_rg.transform.localPosition.y + 0.91f);
    }
    void jump(){
        if (Input.GetButtonDown("Jump")&&collider2D.IsTouchingLayers(Ground) ||inputVertical!=0&&collider2D.IsTouchingLayers(Ground))
        {
            m_rg.velocity = new Vector2(m_rg.velocity.x, MoveSpeed);
        }
    }
}

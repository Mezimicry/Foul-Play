using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaC_characterMove : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector3 target;
    private BoxCollider2D bc;
    private bool isMoving = false;

    void Start()
    {
        //gets the boxcollider and the rigidbody
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Awake()
    {
        target = transform.position;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //the character will stop when colliding with something
        target = transform.position;

    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //left clicking sets a position for the character to move to
            SetTargetPosition();
        }

        if (isMoving)
        {
            MoveToTarget();
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

   

    void LateUpdate()
    {
        //changes layer sorting based on y value
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }

    void SetTargetPosition()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;

        isMoving = true;
    }

    void MoveToTarget()
    {
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            isMoving = false; 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pac_ObjectLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        //changes layer sorting based on y value
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }
}

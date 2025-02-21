using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VN_CharacterScript : MonoBehaviour
{
    float targetDesination = 25;
    float targetSpeed = 0;
    float directionMod = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x  != targetDesination )
        {
            
            transform.position += new Vector3(targetSpeed, 0, 0) * Time.deltaTime * directionMod ;

            if ((transform.position.x > targetDesination && directionMod == 1) | (transform.position.x < targetDesination && directionMod == -1))
            {
                transform.position = new Vector3(targetDesination, 0, 0);
                targetSpeed = 0;
            }
        }
    }

    public void Appear(string sxAxis)
    {
        float xAxis = float.Parse(sxAxis);
        transform.localPosition = new Vector2(xAxis, 0);
        targetDesination = xAxis;
    }

    public void Move(string sXAxis, string sSpeed)
    {
        targetDesination = float.Parse(sXAxis);
        targetSpeed = float.Parse(sSpeed);
        if (targetDesination - transform.position.x > 0)
        {
            directionMod = 1;
        }
        else
        {
            directionMod = -1;
        }

    }
}

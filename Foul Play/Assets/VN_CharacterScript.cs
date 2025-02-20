using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VN_CharacterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector2(0, 0);
    }

    void Update()
    {

    }

    public void Appear(string sxAxis)
    {
        float xAxis = float.Parse(sxAxis);
        transform.localPosition = new Vector2(xAxis, 0);
    }

    public void Move(string sXAxis, string sSpeed)
    {
        float xAxis = float.Parse(sXAxis);
        float speed = float.Parse(sSpeed);
        transform.localPosition = new Vector2(xAxis, 0);
    }



    // Update is called once per frame

}

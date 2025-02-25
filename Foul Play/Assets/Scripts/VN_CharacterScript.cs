using UnityEngine;

public class VN_CharacterScript : MonoBehaviour
{
    // Variables needed for Move and Appear
    // X value that character is moving towards
    float targetDesination;
    // How far the character moves for every 1 delta time
    float targetSpeed;
    // Character is moving in a positive or negative direction
    float directionMod;
    // If the code for moving needs to run
    bool needToMove = false;

    // Array that holds all of the character's sprites
    public Sprite[] sprites;

        void Update()
    {
        // This code only runs when the character need to move
        if (needToMove)
        {
            // Character is moved by the speed multiplied by both the time the frame took and the direction.
            transform.position += new Vector3(targetSpeed, 0, 0) * Time.deltaTime * directionMod;

            // When the character is at a position equal or past its destination
            // It will get set to the destiation, have its speed set to 0, and disable the moving code
            if ((transform.position.x >= targetDesination && directionMod == 1) | (transform.position.x <= targetDesination && directionMod == -1))
            {
                transform.position = new Vector3(targetDesination, 0, 0);
                targetSpeed = 0;
                needToMove = false;
            }
        }
    }

    // Instantly makes the character be in its desired location
    public void Appear(string sxAxis)
    {
        // Stores the desired xAxis
        // Need to parse as the array stores them as a string
        float xAxis = float.Parse(sxAxis);

        // Sets the character to be at the value
        transform.localPosition = new Vector2(xAxis, 0);
        targetDesination = xAxis;
    }

    // Moves the character to its desired location over time
    public void Move(string sXAxis, string sSpeed)
    {
        // Sets the desination and speed
        // Need to parse as the array stores them as a string
        targetDesination = float.Parse(sXAxis);
        targetSpeed = float.Parse(sSpeed);

        // Every frame the character will now run the move code
        needToMove = true;

        // Determines if the movement is a postive one or a negative one
        if (targetDesination - transform.position.x > 0)
        {
            directionMod = 1;
        }
        else
        {
            directionMod = -1;
        }
    }

    // Changes the characters sprite
    public void Change(string spriteNumber)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[int.Parse(spriteNumber)];
    }

}




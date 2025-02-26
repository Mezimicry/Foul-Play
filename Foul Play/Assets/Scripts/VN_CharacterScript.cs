using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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


    // For returning the character to their original possitions
    Vector2 origin = new Vector2(0,0);

    void Start()
    {
        origin = new Vector2(transform.position.x, transform.position.y);
    }


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
    public void Appear(float xAxis)
    {
        transform.localPosition = new Vector2(xAxis, 0);
    }

    // Returns the character to their origianl positon 
    public void Disappear()
    {
        transform.localPosition = origin;
    }


    // Moves the character to its desired location over time
    public void Move(float xAxis, float speed)
    {
        // Sets the desination and speed
        targetDesination = xAxis;
        targetSpeed = speed;

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
    public void Change(int spriteNumber)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteNumber];
    }

}




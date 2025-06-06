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
    // Changes the y ofset if required
    public float yOffset = 2;

    // Array that holds all of the character's sprites
    public Sprite[] sprites;


    // For returning the character to their original possitions
    Vector2 origin = new Vector2(0,0);

    void Start()
    {
        // Stores origin of the character so it can return
        origin = new Vector3(transform.position.x, transform.position.y, -4);
    }


    void Update()
    {
        // This code only runs when the character need to move
        if (needToMove && !gameManager.getMain_Paused())
        {
            // Character is moved by the speed multiplied by both the time the frame took and the direction.
            transform.position += new Vector3(targetSpeed, 0) * Time.deltaTime * directionMod;

            // When the character is at a position equal or past its destination
            // It will use appear to move to that exact location
            if ((transform.position.x >= targetDesination && directionMod == 1) | (transform.position.x <= targetDesination && directionMod == -1))
            {
                Appear(targetDesination);
            }
        }
    }

    /// <summary>
    /// Instantly makes the character be in its desired location + gets them to stop moving
    /// </summary>
    /// <param name="xAxis"></param>
    public void Appear(float xAxis)
    {
        targetSpeed = 0;
        needToMove = false;
        transform.localPosition = new Vector3(xAxis, yOffset, -4);
    }


    /// <summary>
    /// Returns the character to their original positon + gets them to stop moving
    /// </summary>
    public void Disappear()
    {
        targetSpeed = 0;
        needToMove = false;
        transform.localPosition = origin;
    }


    /// <summary>
    /// Moves the character to its desired location over time
    /// </summary>
    /// <param name="xAxis"></param>
    /// <param name="speed"></param>
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

    /// <summary>
    /// Changes the characters sprite
    /// </summary>
    /// <param name="spriteNumber"></param>
    public void Change(int spriteNumber)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteNumber];
    }

}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pac_ObjectLogic : MonoBehaviour
{
    public Transform player;
    public GameObject questionMark;
    public float interactionRange = 2.5f;
    public float glowIntensity = 1.5f;
    public float perspectivePenalty = 0.7f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;




    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        Instantiate(questionMark, new Vector3(transform.position.x, (transform.position.y + 3), transform.position.z), transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = AdjustedDistance(player.position, transform.position);
            {
                if (distance < interactionRange)
                {
                    HighlightObject(true);
                }

                else
                {
                    HighlightObject(false);
                }

            }
        }
    }

    void LateUpdate()
    {
        //changes layer sorting based on y value
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }

    float AdjustedDistance(Vector3 playerPos, Vector3 objectPos)
    {
        float xDiff = playerPos.x - objectPos.x;
        float yDiff = (playerPos.y - objectPos.y) * perspectivePenalty;

        return Mathf.Sqrt((xDiff * xDiff) + (yDiff * yDiff));
    }

    void HighlightObject(bool highlight)
    {
        if (highlight)
        {
            spriteRenderer.color = Color.blue;
        }

        else
        {
            spriteRenderer.color = originalColor;
        }
    }
}

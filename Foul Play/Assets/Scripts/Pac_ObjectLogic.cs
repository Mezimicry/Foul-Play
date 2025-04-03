using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    GameObject personalQuestionMark;

    public GameObject LogicScript;
    public string characterName;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        personalQuestionMark = Instantiate(questionMark, new Vector3(transform.position.x, (transform.position.y + 3), -2.5f), transform.rotation);

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
                    personalQuestionMark.SetActive(true);
                    //HighlightObject(true);
                }

                else
                {
                    personalQuestionMark.SetActive(false);
                    //HighlightObject(false);
                }
            }
        }

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) & (AdjustedDistance(player.position, transform.position) < interactionRange))
        {
            LogicScript.GetComponent<PaC_LogicScript>().characterInteracted(characterName);
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

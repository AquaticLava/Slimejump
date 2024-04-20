using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public Rigidbody2D slimeRigidbody2D;
    private bool onGround = false;
    public int strafeStrength;
    public int jumpStrength;
    public Transform playerTransform;
    public TMP_Text playerNameText;
    
    // Start is called before the first frame update
    void Start()
    {
        playerNameText.text = "bob";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            slimeRigidbody2D.velocity += Vector2.right * strafeStrength;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            slimeRigidbody2D.velocity += Vector2.left * strafeStrength;
        }

        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            slimeRigidbody2D.velocity += Vector2.up * jumpStrength;
            onGround = false;
        }
        if (playerTransform != null && playerNameText != null)
        {
            // Set the text position to be above the player's head
            playerNameText.transform.position = playerTransform.position + Vector3.up * 1.2f;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!onGround || !collision.gameObject.CompareTag("wall"))
        {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("bouncey_paltform") && slimeRigidbody2D.velocity.y < 0)
        {
            slimeRigidbody2D.velocity += Vector2.up * jumpStrength;
            onGround = false;
        }
    }
}

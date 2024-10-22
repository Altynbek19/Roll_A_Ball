using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
// public class NewBehaviourScript : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text winText;
    public TMP_Text LoseText;


    public float speed = 10.0f;
    private Rigidbody rb;
    private int count;

    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();
        winText.gameObject.SetActive(false);
        LoseText.gameObject.SetActive(false);
    }

    void OnMove(InputValue moveMentValue)
    {
        Vector2 movementVector = moveMentValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("dice"))
        {
            other.gameObject.SetActive(false);

            count = count + 5;
            SetCountText();
        }
        if (other.gameObject.CompareTag("barrel"))
        {
            other.gameObject.SetActive(false);

            count = count - 5;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: "+ count.ToString();
        if(count >= 15)
        {   
            if(!LoseText.gameObject.activeSelf)
            {
                winText.gameObject.SetActive(true);
            }
            // winText.gameObject.SetActive(true);

        }
        if(count < -5)
        {
            if(!winText.gameObject.activeSelf)
            {
                LoseText.gameObject.SetActive(true);

            }
        }
    }

}

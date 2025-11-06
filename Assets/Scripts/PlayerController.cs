using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void FixedUpdate()
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
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 2)
        {
            Transform doorsParent = GameObject.Find("Doors").transform;
            Transform door1 = doorsParent.Find("Door1");
            if (door1 != null)
            {
                door1.gameObject.SetActive(false);
            }
        }

        if (count == 5)
        {
            Transform doorsParent = GameObject.Find("Doors").transform;
            Transform door2 = doorsParent.Find("Door2");
            if (door2 != null)
                door2.gameObject.SetActive(false);
        }

        if (count == 8)
        {
            Transform doorsParent = GameObject.Find("Doors").transform;
            Transform door3 = doorsParent.Find("Door3");
            if (door3 != null)
                door3.gameObject.SetActive(false);
        }

        if (count == 10)
        {
            Transform doorsParent = GameObject.Find("Doors").transform;
            Transform door4 = doorsParent.Find("Door4");
            if (door4 != null)
                door4.gameObject.SetActive(false);
        }

        if (count >= 12)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
}

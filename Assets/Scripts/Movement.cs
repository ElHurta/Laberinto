using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;
    Vector3 initialPosition;
    int coins = 0;
    int health = 3;
    public TMP_Text coinsText;
    public TMP_Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;

        coinsText.text = "Score: " + coins;
        healthText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector3(x, 0, y) * speed);
    }

    void OnTriggerEnter(Collider collider){
  
        if(collider.CompareTag("Coin")){
            coins++;
            Debug.Log("Coins: " + coins);
            coinsText.text = "Score: " + coins;
            Destroy(collider.gameObject);
        }
        if(collider.CompareTag("Goal")){
            Debug.Log("You win!");
            transform.position = initialPosition;
        }
        if(collider.CompareTag("Enemy")){

            health--;
            Debug.Log("Health: " + health);
            transform.position = initialPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            healthText.text = "Health: " + health;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{

    public float Speed;
    Vector3 movement;
    private Rigidbody rb;
    private int amountCoins = 0;
    public TextMeshProUGUI coinTxt;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity += movement * Time.deltaTime * Speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        
        
        if ( other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
                amountCoins = amountCoins + 1;
                coinTxt.text = amountCoins.ToString();
        }
        if ( other.gameObject.CompareTag("DoorTrigger")&& amountCoins>=2)
        {
            other.GetComponent<Animator>().SetTrigger("Door");
        }
        

    }

    

    
}

    

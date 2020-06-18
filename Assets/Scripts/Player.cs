using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Rigidbody rb;
    public float jumpForce;
    public float yMax = 3f;
    public float yMin = -5.5f;
    public float onFloor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        
        onFloor = transform.position.y;        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& transform.position.y <= yMax)
        {
            jumpForce = 5f;
            thisAnimation.Play();
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);           
        }

        if (transform.position.y > yMax)
        {
            jumpForce = 0;
        }
        
        else if(transform.position.y <= yMin) 
        {
            Destroy(gameObject);
            SceneManager.LoadScene("EndGame"); 
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag.Equals("Wall")) 
        {
            print("wall");
            SceneManager.LoadScene("EndGame");     
        }
        if (other.gameObject.tag.Equals("Points"))
        {
            print("point");

            GameManager.Score  ++;
        }
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 90.0f;
    private Rigidbody playerRb;
    private float zbound = 6.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ConstrainPlayerPosition();
    }

    // Moves the player based on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    // Prevent player from leaving the screen on top and bottom
   void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zbound);
        }

        if (transform.position.z > zbound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zbound);
        }
    }

  private void OnCollisionEnter(Collision collision)
  {
     if (collision.gameObject.CompareTag("Enemy"))
     {
         Debug.Log("Player collided with enemy!");
     }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Powerup"))
    {
        Destroy(other.gameObject);
    }
  }
}

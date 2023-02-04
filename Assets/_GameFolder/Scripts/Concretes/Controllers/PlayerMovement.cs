using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float crouchSpeed = 5f;
    public float pushForce = 5f;
    public float pullForce = 5f;

    private bool isCrouching = false;
    private bool isGrounded = false;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, 0);

        if (isCrouching)
        {
            transform.position += direction * crouchSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
        }

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position, direction, out hit, 2f))
        //    {
        //        if (hit.collider.CompareTag("Pushable"))
        //        {
        //            //hit.rigidbody.AddForce(direction * pushForce, ForceMode.Impulse);
        //            hit.collider.gameObject.GetComponent<FixedJoint>().enabled = true;
        //        }
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position, -direction, out hit, 2f))
        //    {
        //        if (hit.collider.CompareTag("Pushable"))
        //        {
        //            hit.rigidbody.AddForce(-direction * pullForce, ForceMode.Impulse);
        //        }
        //    }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            //}
            //if (collision.gameObject.tag == "Pushable")
            //{
            //    Debug.Log("pushable");
            //    if (Input.GetKeyDown(KeyCode.E))
            //    {
            //        collision.gameObject.GetComponent<FixedJoint>().enabled = true;

            //        //collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce, ForceMode.Impulse);
            //    }

            //    if (Input.GetKeyDown(KeyCode.Q))
            //    {
            //        collision.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * pullForce, ForceMode.Impulse);
            //    }
            //}
        }
        //private void OnCollisionStay(Collision collision)
        //{
        //    if (collision.gameObject.tag == "Pushable")
        //    {
        //        Debug.Log("pushable");
        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * pushForce, ForceMode.Impulse);
        //        }

        //        if (Input.GetKeyDown(KeyCode.Q))
        //        {
        //            collision.gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * pullForce, ForceMode.Impulse);
        //        }
        //    }
        //}
    }
}

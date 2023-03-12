using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    //I know the code sucks but I was in 8th grade when I made it so that's my excuse

    //camera
    public Vector2 rotation;
    public float sensitivity;
    public float speed;

    //movement
    public Rigidbody rigidbodyCam;
    public float jetRotateSpeed;

    //jet spin
    public Transform jetBody;
    public float jetSensitivity;
    public float jetStop;



    //remember to use *Time.deltaTime;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        // 
        //input values
        rotation.y -= Input.GetAxis("Mouse Y") * jetRotateSpeed;
        rotation.y = Mathf.Clamp(rotation.y, -70, 70);



        if (Input.GetAxis("Horizontal") > 0)
        {
            Vector3 direction = new Vector3(jetBody.rotation.eulerAngles.x, jetBody.rotation.eulerAngles.y, -jetStop);
            Quaternion targetRotation = Quaternion.Euler(direction);
            jetBody.rotation = Quaternion.Lerp(jetBody.rotation, targetRotation, Time.deltaTime * 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Vector3 direction = new Vector3(jetBody.rotation.eulerAngles.x, jetBody.rotation.eulerAngles.y, jetStop);
            Quaternion targetRotation = Quaternion.Euler(direction);
            jetBody.rotation = Quaternion.Lerp(jetBody.rotation, targetRotation, Time.deltaTime * 1);
        }
        else
        {
            Vector3 direction = new Vector3(jetBody.rotation.eulerAngles.x, jetBody.rotation.eulerAngles.y, 0);
            Quaternion targetRotation = Quaternion.Euler(direction);
            jetBody.rotation = Quaternion.Lerp(jetBody.rotation, targetRotation, Time.deltaTime * 1);
        }

        rigidbodyCam.velocity = transform.forward * speed + transform.right * Input.GetAxis("Horizontal") * speed;

        transform.localRotation = Quaternion.Euler(rotation.y, rotation.x, transform.rotation.z);
        
    
}
}

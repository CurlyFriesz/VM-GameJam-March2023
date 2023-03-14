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
    public Transform camTransform;

    //movement
    public Rigidbody rigidbodyCam;
    public float jetRotateSpeed;
    Vector3 previousVelocity;

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

    private void jetBodyLerp(float z)
    {
        Vector3 direction = new Vector3(jetBody.rotation.eulerAngles.x, jetBody.rotation.eulerAngles.y, z);
        Quaternion targetRotation = Quaternion.Euler(direction);
        jetBody.rotation = Quaternion.Lerp(jetBody.rotation, targetRotation, Time.deltaTime * 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rigidbodyAcceleration = (rigidbodyCam.velocity - previousVelocity) / Time.fixedDeltaTime;

        camTransform.position = new Vector3(camTransform.position.x, camTransform.position.y - rigidbodyAcceleration.y, camTransform.position.z);

        //Rotates vehicle up and down
        rotation.y -= Input.GetAxis("Mouse Y") * jetRotateSpeed;
        rotation.y = Mathf.Clamp(rotation.y, -70, 70);


        //Rotates vehicle left and right
        if (Input.GetAxis("Horizontal") > 0) jetBodyLerp(-jetStop);

        else if (Input.GetAxis("Horizontal") < 0) jetBodyLerp(jetStop);

        else jetBodyLerp(0);


        //Vehicle movement
        rigidbodyCam.velocity = transform.forward * speed + transform.right * Input.GetAxis("Horizontal") * speed;

        transform.localRotation = Quaternion.Euler(rotation.y, rotation.x, transform.rotation.z);

        previousVelocity = rigidbodyCam.velocity;
}       
}

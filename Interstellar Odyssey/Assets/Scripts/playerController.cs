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
    public Rigidbody rigidbodyVehicle;
    public float jetRotateSpeed;
    Vector3 previousVelocity = Vector3.zero;
    public float maxForwardVelocity;
    public float Acceleration;
    public float ACCelEnergy;
    private Vector3 currVel;


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
        jetBody.rotation = Quaternion.Lerp(jetBody.rotation, targetRotation, Time.deltaTime * jetRotateSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        //Rotates vehicle up and down
        rotation.y -= Input.GetAxis("Mouse Y") * jetSensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -70, 70);


        //Rotates vehicle left and right
        if (Input.GetAxis("Horizontal") > 0) jetBodyLerp(-jetStop);

        else if (Input.GetAxis("Horizontal") < 0) jetBodyLerp(jetStop);

        else jetBodyLerp(0);


        //Vehicle movement
        currVel = transform.forward * speed + transform.right * Input.GetAxis("Horizontal") * speed;

        if (Input.GetMouseButton(0)) currVel.z += Acceleration * Time.deltaTime;


        rigidbodyVehicle.velocity = currVel;

        transform.localRotation = Quaternion.Euler(rotation.y, rotation.x, transform.rotation.z);

        
}       
}

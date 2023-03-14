using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{


    //camera
    public Vector2 rotation;
    public float sensitivity;
    public Transform camTransform;

    //movement
    public Rigidbody rigidbodyVehicle;
    public float jetRotateSpeed;

    public float speed;
    public float maxSpeed;


    public float Acceleration;
    public float ACCelEnergy;
    private Vector3 currVel;


    //jet spin
    public Transform jetBody;
    public float jetSensitivity;
    public float jetStop;


    //Boost code
    public ParticleSystem[] boostList;

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






        // boost/movement(not working, will fix later)

        currVel = transform.forward * speed + transform.right * Input.GetAxis("Horizontal") * speed;
        if (Input.GetMouseButton(0))
        {
            currVel.z += Acceleration * Time.deltaTime; 
            for(int i = 0; i < 3; i++)
            {
                if (boostList[i].startColor != Color.blue)
                {
                    boostList[i].Stop();
                    boostList[i].startColor = Color.blue;
                    boostList[i].Play();
                }
            }
            Debug.Log(Acceleration * Time.deltaTime);
        }
        else
        {
            currVel.z -= Acceleration * Time.deltaTime;
            for (int i = 0; i < 3; i++)
            {
                if (boostList[i].startColor != Color.red)
                {
                    boostList[i].Stop();
                    boostList[i].startColor = Color.red;
                    boostList[i].Play();
                }
            }
        }
        currVel.z = Mathf.Clamp(currVel.z, speed, maxSpeed);




        //Vehicle movement


        


        rigidbodyVehicle.velocity = currVel;

        transform.localRotation = Quaternion.Euler(rotation.y, rotation.x, transform.rotation.z);

        
}       
}

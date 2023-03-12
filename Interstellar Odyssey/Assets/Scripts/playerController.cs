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

    //jet spin
    public Transform jetBody;
    public float jetSensitivity;   
    private float rotationJet;

    //boost
    public int cooldownTotal;
    public int boostEnergy;
    public int boostCoolDown;
    
    public bool regen;
    public float boostActive;
    public float jetBoostSpeed = 3;
    public ParticleSystem thruster;
    public ParticleSystem thruster2;
    public ParticleSystem thruster3;
    public ParticleSystem thruster4;
    public ParticleSystem coolEffect;
    public Color color1 = new Vector4(1f, 1f, 1f, 0.2f);
    public Color color2 = new Vector4(0f, 0f, 1f, 1f);
    public bool boostOn = true;
    public bool redBoost = true;





    //remember to use *Time.deltaTime;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        boostCoolDown = boostEnergy;
        cooldownTotal = boostCoolDown;        
    }

    // Update is called once per frame
    void Update()
    {
        // 
        //input values
        rotation.x += Input.GetAxis("Mouse Y") * sensitivity;
        rotation.x = Mathf.Clamp(rotation.x, -70f, 70f);

        //Rotates spacecraft
        if (Input.GetAxis("Horizontal") > 0 && jetBody.rotation.z < 80) 
        {
            jetBody.Rotate(Input.GetAxis("Horizontal") * jetSensitivity * Vector3.back);
        }
        else if(Input.GetAxis("Horizontal") < 0 && jetBody.rotation.z > -80)
        {
            jetBody.Rotate(Input.GetAxis("Horizontal") * jetSensitivity * Vector3.back);
        }







        rigidbodyCam.velocity = transform.forward * speed + transform.right * Input.GetAxis("Horizontal") * speed;

        //boost code
        /*if (boostActive >= 0.4){ 
            boostEnergy -=1;
            boostCoolDown -=1;          
            if (boostEnergy > 0){
                if (boostOn == false){
                    Debug.Log("amongus");
                    boostOn = true;
                    var mainParticle = thruster.main;  
                    var sideEffect = coolEffect .main;
                    coolEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                    sideEffect.simulationSpeed = sideEffect.simulationSpeed * 2;
                    sideEffect.startColor = color2;
                    coolEffect.Play(true);

                    thruster.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                    mainParticle.startColor = Color.blue;
                    thruster.Play(true);

                    var mainParticle2 = thruster2.main;                
                    thruster2.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                    mainParticle2.startColor = Color.blue;
                    thruster2.Play(true);

                    var mainParticle3 = thruster3.main;                
                    thruster3.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                    mainParticle3.startColor = Color.blue;
                    thruster3.Play(true);

                    var mainParticle4 = thruster4.main;                
                    thruster4.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                    mainParticle4.startColor = Color.blue;
                    thruster4.Play(true);
                }
                redBoost = false;
                rigidbodyCam.velocity = transform.forward * speed * jetBoostSpeed;         

                                
            }
            else{redBoost = true;}

        }else{redBoost = true;}
        if (boostEnergy <= -20){
            boostEnergy = -20;    
        }
        if(redBoost == true){
            if (boostOn == true){
                boostOn = false;
                var sideEffect = coolEffect .main;
                coolEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                sideEffect.simulationSpeed = sideEffect.simulationSpeed/2;
                sideEffect.startColor = color1;
                coolEffect.Play(true);
                var mainParticle = thruster.main;                
                thruster.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                mainParticle.startColor = Color.red;
                thruster.Play(true);

                var mainParticle2 = thruster2.main;                
                thruster2.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                mainParticle2.startColor = Color.red;
                thruster2.Play(true);

                var mainParticle3 = thruster3.main;                
                thruster3.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                mainParticle3.startColor = Color.red;
                thruster3.Play(true);

                var mainParticle4 = thruster4.main;                
                thruster4.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                mainParticle4.startColor = Color.red;
                thruster4.Play(true);

            }
            if (boostCoolDown < cooldownTotal){
                    boostCoolDown += 1;
                }
            if (boostCoolDown >= cooldownTotal/2){
                if (boostEnergy < cooldownTotal){
                    boostEnergy += 1 ;   
                }    
            }
        }*/
        //boost code close

        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        /*if (rotation.y <=-90  && rotation.y >=-270|| rotation.y>= 90&& rotation.y <=270){
            transform.localRotation = Quaternion.Euler(-rotation.y, -rotation.x, transform.rotation.z);
        }
        else{
            transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, transform.rotation.z);
        }*/
    
}
}

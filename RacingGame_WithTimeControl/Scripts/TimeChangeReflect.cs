using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChangeReflect : MonoBehaviour
{
    Rigidbody rigidbody;

    AudioSource audioS;


    Player player;

    float susSpringDef;
    float damperDef;

    float SlowEffectTime = 10.0f;
    
    bool first = false;
    bool second = false;

    float duration0 = 0f;
    float duration1 = 0f;
    float duration2 = 0f;
    float duration3 = 0f;

    float timeStrenght0 = 1f;
    float timeStrenght1 = 1f;
    float timeStrenght2 = 1f;
    float timeStrenght3 = 1f;

    bool invoke0 = false;
    bool invoke1 = false;
    bool invoke2 = false;
    bool invoke3 = false;

    bool first0 = false;
    bool first1 = false;
    bool first2 = false;
    bool first3 = false;

    float time = 0;
    public float TimeScale = 0.2f;

    bool slowMO = false;
    bool fastMO = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        if(player)        susSpringDef = player.allWheels[0].suspensionSpring.spring;

        time = 0;
        rigidbody = GetComponent<Rigidbody>();
       
        if(player) damperDef = player.allWheels[0].suspensionSpring.damper;

    }
    //Transform Time Control
    public void TransformSlow(float slowDuration, float slowStrenght)
    {

    }

    public void TransformFast(float fastDuration, float fastStrenght)
    {

    }
  
  //ZrobicTuPotem WYŻEJ SLOW NA TRANSLATE
    public void SlowMe(float slowDuration, float slowStrenght)
    {
        duration0 = slowDuration;
        timeStrenght0 = slowStrenght;
        invoke0 = true;
    }

    public void SlowMeSTOP()
    {
        invoke0 = false;
    }

    public void SlowSth(float slowDuration, float slowStrenght)
    {
        duration1 = slowDuration;
        timeStrenght1 = slowStrenght;
        invoke1 = true;
    }

    public void FastMe(float fastDuration, float fastStrenght)
    {
        duration2 = fastDuration;
        timeStrenght2 = fastStrenght;
        invoke2 = true;
    }
    
    public void FastMeSTOP()
    {
        invoke2 = false;
    }

    public void FastSth(float fastDuration, float fastStrenght)
    {
        duration3 = fastDuration;
        timeStrenght3 = fastStrenght;
        invoke3 = true;

    }


    

    void Update()
    {
        if(gameObject.tag == "Player") slowMO = Input.GetKey(KeyCode.Z);
        if (gameObject.tag == "Player") fastMO = Input.GetKey(KeyCode.C);

        time += Time.deltaTime;

        if (invoke0) duration0 -= Time.deltaTime;
        if (invoke1) duration1 -= Time.deltaTime;
        if (invoke2) duration2 -= Time.deltaTime;
        if (invoke3) duration3 -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        //FUNKCJA SLOW ME
        if(invoke0)
        {
            
            if (!first0)
            {
                rigidbody.mass /= timeStrenght0;
                rigidbody.velocity *= timeStrenght0;
                rigidbody.angularVelocity *= timeStrenght0;
                rigidbody.useGravity = false;
               // player.acceleration /= (timeStrenght0 * timeStrenght0);

                foreach (WheelCollider wheel in player.allWheels)
                {
                    JointSpring suspensionSpring = new JointSpring();
                    suspensionSpring.spring = susSpringDef / timeStrenght0;
                    suspensionSpring.damper = damperDef / timeStrenght0;
                    suspensionSpring.targetPosition = wheel.suspensionSpring.targetPosition;
                    wheel.suspensionSpring = suspensionSpring;
                }

            }

            float dt = Time.fixedDeltaTime * timeStrenght0;

            rigidbody.AddForce(Vector3.down * Mathf.Abs(Physics.gravity.magnitude) * rigidbody.mass * timeStrenght0 * timeStrenght0);


            if (duration0 <= 0) invoke0 = false;
            first0 = true;

        }else if(first0)
        {

            float dt = Time.fixedDeltaTime * timeStrenght0;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass *= timeStrenght0;
            rigidbody.velocity /= timeStrenght0;
            rigidbody.angularVelocity /= timeStrenght0;
          //  player.acceleration *= (timeStrenght0 * timeStrenght0);

            foreach (WheelCollider wheel in player.allWheels)
            {
                JointSpring suspensionSpring = new JointSpring();
                suspensionSpring.spring = susSpringDef * timeStrenght0;
                suspensionSpring.damper = damperDef * timeStrenght0;
                suspensionSpring.targetPosition = wheel.suspensionSpring.targetPosition;
                wheel.suspensionSpring = suspensionSpring;
            }

            first0 = false;
        }
        //FUNKCJA SLOW STH
        if (invoke1)
        {
            if (!first1)
            {
                rigidbody.mass /= timeStrenght1;
                rigidbody.velocity *= timeStrenght1;
                rigidbody.angularVelocity *= timeStrenght1;
                rigidbody.useGravity = false;
                audioS = transform.GetChild(0).GetComponent<AudioSource>();
                audioS.mute = false;
            }

           
            float dt = Time.fixedDeltaTime * timeStrenght1;

            rigidbody.AddForce(Vector3.down * Mathf.Abs(Physics.gravity.magnitude) * rigidbody.mass * timeStrenght1 * timeStrenght1);


            if (duration1 <= 0) invoke1 = false;
            first1 = true;

            

        }
        else if (first1)
        {

            float dt = Time.fixedDeltaTime * timeStrenght1;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass *= timeStrenght1;
            rigidbody.velocity /= timeStrenght1;
            rigidbody.angularVelocity /= timeStrenght1;
            audioS.mute = true;

            first1 = false;
        }
        // FUNKCJA FAST ME
        if (invoke2)
        {
            if (!first2)
            {
                rigidbody.mass *= timeStrenght2;
                rigidbody.velocity /= timeStrenght2;
                
                rigidbody.angularVelocity /= timeStrenght2;
                rigidbody.useGravity = false;
                player.acceleration *= (timeStrenght2 * timeStrenght2);

                foreach (WheelCollider wheel in player.allWheels)
                {
                    JointSpring suspensionSpring = new JointSpring();
                    suspensionSpring.spring = susSpringDef * timeStrenght2;
                    suspensionSpring.damper = damperDef * timeStrenght2;
                    suspensionSpring.targetPosition = wheel.suspensionSpring.targetPosition;
                    wheel.suspensionSpring = suspensionSpring;
                }
            }
            float dt = Time.fixedDeltaTime / timeStrenght2;

            //rigidbody.AddForce(Vector3.down / Mathf.Abs(Physics.gravity.magnitude) / rigidbody.mass / timeStrenght2 / timeStrenght2);


            if (duration2 <= 0) invoke2 = false;
            first2 = true;

        }
        else if (first2)
        {

            float dt = Time.fixedDeltaTime / timeStrenght2;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass /= timeStrenght2;
            rigidbody.velocity *= timeStrenght2;
            rigidbody.angularVelocity *= timeStrenght2;
            player.acceleration /= (timeStrenght2 * timeStrenght2);

            first2 = false;
        }
        else
        {
            if (player)
            {
                foreach (WheelCollider wheel in player.allWheels)
                {

                    if (wheel.suspensionSpring.spring <= susSpringDef && wheel.suspensionSpring.damper <= damperDef)
                    {
                        JointSpring suspensionSpring = new JointSpring();
                        if (wheel.suspensionSpring.spring <= susSpringDef) suspensionSpring.spring++;
                        if (wheel.suspensionSpring.damper <= damperDef) suspensionSpring.damper++;
                        //suspensionSpring.spring = susSpringDef / TimeScale;
                        // suspensionSpring.damper = damperDef / TimeScale;
                        suspensionSpring.targetPosition = wheel.suspensionSpring.targetPosition;
                        wheel.suspensionSpring = suspensionSpring;
                    }
                }
            }
        }

        // FUNKCJA FAST STH
        if (invoke3)
        {
            if (!first3)
            {
                rigidbody.mass *= timeStrenght3;
                rigidbody.velocity /= timeStrenght3;
                rigidbody.angularVelocity /= timeStrenght3;
                rigidbody.useGravity = false;
                audioS = transform.GetChild(1).GetComponent<AudioSource>();
                audioS.mute = false;
            }
            float dt = Time.fixedDeltaTime / timeStrenght3;

            rigidbody.AddForce(Vector3.down / Mathf.Abs(Physics.gravity.magnitude) / rigidbody.mass / timeStrenght3 / timeStrenght3);


            if (duration3 <= 0) invoke3 = false;
            first3 = true;

        }
        else if (first3)
        {
            float dt = Time.fixedDeltaTime / timeStrenght3;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass /= timeStrenght3;
            rigidbody.velocity *= timeStrenght3;
            rigidbody.angularVelocity *= timeStrenght3;
            audioS.mute = true;


            first3 = false;
        }




        // Slowing down on Z
        if (slowMO)
        {
            if(!first)
            {
                rigidbody.mass /= TimeScale;
                rigidbody.velocity *= TimeScale;
                rigidbody.angularVelocity *= TimeScale;
                rigidbody.useGravity = false;
               // player.acceleration /= (TimeScale * TimeScale);

                foreach (WheelCollider wheel in player.allWheels)
                {
                    JointSpring suspensionSpring = new JointSpring();
                    suspensionSpring.spring = susSpringDef / TimeScale;
                    suspensionSpring.damper = damperDef / TimeScale;
                    suspensionSpring.targetPosition = wheel.suspensionSpring.targetPosition;
                    wheel.suspensionSpring = suspensionSpring;
                }

            }
            float dt = Time.fixedDeltaTime * TimeScale;
            
            rigidbody.AddForce(Vector3.down*Mathf.Abs(Physics.gravity.magnitude)*rigidbody.mass*TimeScale*TimeScale);
            
                                       
            first = true;
        }
        else if(first)
        {
            
            float dt = Time.fixedDeltaTime * TimeScale;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass *= TimeScale;
            rigidbody.velocity /= TimeScale;
            rigidbody.angularVelocity /= TimeScale;
            //player.acceleration *= (TimeScale * TimeScale);
            foreach (WheelCollider wheel in player.allWheels)
            {
                JointSpring suspensionSpring = new JointSpring();
                suspensionSpring.spring = susSpringDef * TimeScale;
                suspensionSpring.damper = damperDef * TimeScale;
                suspensionSpring.targetPosition = wheel.suspensionSpring.targetPosition;
                wheel.suspensionSpring = suspensionSpring;
            }

            first = false;
        }


        //Fasting Up on C
        if (fastMO)
        {
            if (!second)
            {
                rigidbody.mass *= TimeScale;
                rigidbody.velocity /= TimeScale;
                rigidbody.angularVelocity /= TimeScale;
                rigidbody.useGravity = true;
                player.acceleration *= (TimeScale * TimeScale);

                foreach (WheelCollider wheel in player.allWheels)
                {
                    JointSpring suspensionSpring = new JointSpring();
                    suspensionSpring.spring = susSpringDef * TimeScale;
                    suspensionSpring.damper = damperDef * TimeScale;
                    suspensionSpring.targetPosition = wheel.suspensionSpring.targetPosition;
                    wheel.suspensionSpring = suspensionSpring;
                }

            }
            float dt = Time.fixedDeltaTime / TimeScale;

            //rigidbody.AddForce(Vector3.down / Mathf.Abs(Physics.gravity.magnitude) / rigidbody.mass / TimeScale / TimeScale);


            second = true;
        }
        else if (second)
        {

            float dt = Time.fixedDeltaTime / TimeScale;
            rigidbody.useGravity = true;
            //rigidbody.velocity += Physics.gravity * dt;
            rigidbody.mass /= TimeScale;
            rigidbody.velocity *= TimeScale;
            player.acceleration /= (TimeScale * TimeScale);
            rigidbody.angularVelocity *= TimeScale;



            second = false;
        }
        else
        {
            if (player)
            { 
                foreach (WheelCollider wheel in player.allWheels)
                {

                    if (wheel.suspensionSpring.spring <= susSpringDef && wheel.suspensionSpring.damper <= damperDef)
                    {
                        JointSpring suspensionSpring = new JointSpring();
                        if (wheel.suspensionSpring.spring <= susSpringDef) suspensionSpring.spring++;
                        if (wheel.suspensionSpring.damper <= damperDef) suspensionSpring.damper++;
                        //suspensionSpring.spring = susSpringDef / TimeScale;
                        // suspensionSpring.damper = damperDef / TimeScale;
                        suspensionSpring.targetPosition = wheel.suspensionSpring.targetPosition;
                        wheel.suspensionSpring = suspensionSpring;
                    }
                }
            }
        }


    }


   /* void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 500, 100), "Velovity    " + rigidbody.velocity.magnitude.ToString());
        GUI.Label(new Rect(0, 15, 500, 100), "Mass    " + rigidbody.mass.ToString());
        GUI.Label(new Rect(0, 30, 500, 100), "TimeScale    " + Time.timeScale.ToString());
        GUI.Label(new Rect(0, 45, 500, 100), "Z    " + (Input.GetKey(KeyCode.Z) ? "1":"0"));
        GUI.Label(new Rect(0, 60, 500, 100), "AngularVelocity    " + rigidbody.angularVelocity.magnitude.ToString(),ToString());
        GUI.Label(new Rect(0, 75, 500, 100), "Accel   " + rigidbody.velocity.magnitude/(time),ToString());
        GUI.Label(new Rect(0, 90, 500, 200), "Spring   " + player.allWheels[0].suspensionSpring.spring.ToString(), ToString());
        GUI.Label(new Rect(0, 105, 500, 200), "Damper   " + player.allWheels[0].suspensionSpring.damper.ToString(), ToString());
    }*/
}

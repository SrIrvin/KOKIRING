using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPly : MonoBehaviour
{
    private CharacterController chrCtrl;
    private Transform tr;
    private Animator anim;
    
   

    public Transform cam;
    public float vel = 10;
    public float turnSmoothTime = 0.9f;
    float turnSmoothVel;
    public float grav = 9.6f;
    public float jumpspeed = 3.5f;
    public float DiretionY=0;
 
    void Start()
    {
        chrCtrl = GetComponent<CharacterController>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0.0f, vertical).normalized;

        //Animaciones
        anim.SetBool("caminar", dir.magnitude >= 0.1f);
        anim.SetBool("jump",  DiretionY>-5 && Input.GetKeyDown(KeyCode.Space));



        if (chrCtrl.isGrounded) { grav = 0; DiretionY = -0.1f; }
        else grav = 9.3f;


        if (dir.magnitude >= 0.1f || !chrCtrl.isGrounded) {
            
            float targetangle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angl = Mathf.SmoothDampAngle(tr.eulerAngles.y, targetangle,ref turnSmoothVel, turnSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0.0f, targetangle, 0.0f) * Vector3.forward;

            if (Input.GetKeyDown( KeyCode.Space   ) && chrCtrl.isGrounded )
            {
                DiretionY = jumpspeed;
            }

            if(DiretionY>-5.2f )
            DiretionY -= grav *Time.deltaTime ;

            moveDir.y = DiretionY;

            tr.transform.rotation = Quaternion.Euler(0.0f, angl, 0.0f);
            chrCtrl.Move(moveDir.normalized * vel * Time.deltaTime);
        }
        

    }
}

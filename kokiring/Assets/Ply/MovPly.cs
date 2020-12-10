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
        var data= GetComponent<SaveData>();
        if( PlayerPrefs.HasKey("save") )
        if (PlayerPrefs.GetInt("save") == 1 && data.ExistFile("player") )
        {
            string pos = data.LoadKey<string>("player");
            tr.transform.position = data.StringToVector3(pos) ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0.0f, vertical).normalized;
        if (Input.GetKey(KeyCode.LeftShift ) && vel<60) {
            vel += 1;
        } else vel = 20;

        //Animaciones
        anim.SetBool("caminar", dir.magnitude >= 0.1f);
        //anim.SetBool("jump",  DiretionY>-5 && Input.GetButtonDown("Jump"));
        anim.SetBool("jump", !chrCtrl.isGrounded);


        if (chrCtrl.isGrounded) { grav = 0.1F; DiretionY = -0.1f; }
        else grav = 9.3f;


        if (dir.magnitude >= 0.1f || !chrCtrl.isGrounded)
        {
            float targetangle;
            if (Input.GetAxis("Vertical") < 0.0f)
            {
                targetangle = Mathf.Atan2(-dir.x, -dir.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            }
            else
            {
                targetangle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            }
            float angl = Mathf.SmoothDampAngle(tr.eulerAngles.y, targetangle, ref turnSmoothVel, turnSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0.0f, targetangle, 0.0f) * Vector3.forward;

            if (Input.GetButtonDown("Jump") && chrCtrl.isGrounded)
            {
                DiretionY = jumpspeed;
            }


            if (DiretionY > -5.2f)
                DiretionY -= grav * Time.deltaTime;

            moveDir.y = DiretionY;

            tr.transform.rotation = Quaternion.Euler(0.0f, angl, 0.0f);
            chrCtrl.Move(moveDir.normalized * vel * Time.deltaTime);
        }
        else {
            if (Input.GetButtonDown("Jump") && chrCtrl.isGrounded)
            {
                DiretionY = jumpspeed;
                anim.Play("callendo");
            }


            if (DiretionY > -5.2f)
                DiretionY -= grav * Time.deltaTime;

            chrCtrl.Move(new Vector3(0.0f, DiretionY, 0.0f) * vel * Time.deltaTime);

        }
       
        

    }
}

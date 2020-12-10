using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script de movimiento del jugador.
public class MovPly : MonoBehaviour
{
    // Componentes del GameObjet a utilizar
    private CharacterController chrCtrl; 
    private Transform tr;
    private Animator anim;
    
   

    public Transform cam;               // Pocicion de la camara.
    public float dafaultVel = 20;       // Velocidad por defento
    public float vel;                   // Velocidad aplicada
    public float turnSmoothTime = 0.9f; // Indice de suabisado de de rotación 
    float turnSmoothVel;                // Indice de suabisado de celocidad
    public float grav = 9.6f;           // Gravedad aplicada
    public float jumpspeed = 3.5f;      // Indice de salto
    public float DiretionY=0;           // Ayuda a guradar ultimo indice de movimiento aplicado en "grav" .
 
    void Start()
    {
        vel = dafaultVel;
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
        } else vel = dafaultVel;

        if (chrCtrl.isGrounded) { grav = 0.1f; DiretionY = -0.1f; }
        else grav = 9.3f;


        anim.SetBool("caminar", dir.magnitude >= 0.1f);
        anim.SetBool("jump", !chrCtrl.isGrounded);

        if (dir.magnitude >= 0.1f || !chrCtrl.isGrounded)
        {
            
            float targetAngle;
            if ( vertical < 0.0f && horizontal==0 )
            {
                targetAngle = Mathf.Atan2(-dir.x, -dir.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            }
            else
            {
                targetAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            }


            float angl = Mathf.SmoothDampAngle(tr.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            Vector3 moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;

            Salto();
            Gravedad(false);
            moveDir.y = DiretionY;

            tr.transform.rotation = Quaternion.Euler(0.0f, angl, 0.0f);
            chrCtrl.Move(moveDir.normalized * vel * Time.deltaTime);
        }
        else {
            Salto();
            Gravedad(true);
        }
       
        

    }

    // Suma velocidad
    public void addVel(float plus) {
        dafaultVel+=plus;
    }

    // Aplicar salto.
    public void Salto() {
        if (Input.GetButtonDown("Jump") && chrCtrl.isGrounded)
        {
            DiretionY = jumpspeed;
            anim.Play("callendo");
        }
    }

    // Aplicar Gravedad.
    public void Gravedad(bool aply)
    {
        if (DiretionY > -5.2f)
            DiretionY -= grav * Time.deltaTime;
        if (aply)
            chrCtrl.Move(new Vector3(0.0f, DiretionY, 0.0f) * vel * Time.deltaTime);
        
    }
}

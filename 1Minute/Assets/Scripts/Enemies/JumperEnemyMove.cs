using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumperEnemyMove : MonoBehaviour
{

    Rigidbody2D ManRigidBody;
    Animator KarakterAnimator;

    //public float tekrarx;

    public float harekethizi;
    public float ziplamahizi;
    public float death_jump_hiz;

    public bool yerdemi = false;
    public Transform ZeminPozisyonKontrol;
    public float ZeminCapKontrol;
    public int BirdahakiZiplanacakZaman, ZiplamaFrequency;
    public LayerMask ZeminKatmanKontrol;

    bool FaceRight = false;

    public int modal1;
    public int modalsonuc;

  //  public static dusmanhareket Cagir_dusman;
    void Start()
    {
       // Cagir_dusman = this;
        ManRigidBody = GetComponent<Rigidbody2D>();
        KarakterAnimator = GetComponent<Animator>();

    }


    void FixedUpdate()
    {

        Modfonk();



        if (yerdemi == false)
        {
            if (modalsonuc == 1)
            {
                ManRigidBody.velocity = new Vector2(1f * harekethizi, ManRigidBody.velocity.y);     //bu da oluyor//
                                                                                                    // ManRigidBody.AddForce(new Vector2(tekrarx, 0f)); 
            }
            else if (modalsonuc == 0)
            {

                ManRigidBody.velocity = new Vector2(-1f * harekethizi, ManRigidBody.velocity.y);
                //  ManRigidBody.AddForce(new Vector2(-tekrarx  , 0f));
            }

        }

        else if (yerdemi)
        {

            ManRigidBody.velocity = new Vector2(0f, ManRigidBody.velocity.y); //0f de farklý ManRigidBody.velocity.x


        }




        yerControl();





        if (ManRigidBody.velocity.x< 0 && FaceRight)
        {
            Faceturn();
        }
        else if (ManRigidBody.velocity.x>0 && !FaceRight)
        {


            Faceturn();


        }



        if (yerdemi && (BirdahakiZiplanacakZaman < Time.timeSinceLevelLoad))
        {
            BirdahakiZiplanacakZaman = (int)Time.timeSinceLevelLoad + ZiplamaFrequency;



            Zipla();


        }


    }
    void Faceturn()
    {

        FaceRight = !FaceRight;

        Vector3 boyut3 = transform.localScale;

        boyut3.x *= -1;

        transform.localScale = boyut3;


    }

    public void Zipla()
    {
        ManRigidBody.velocity = new Vector2(ManRigidBody.velocity.x, ziplamahizi);
        //   ManRigidBody.AddForce(new Vector2(ziplamayatayhiz, ziplamahizi));
    }
    public void death_jump()
    {
        ManRigidBody.velocity = new Vector2(0f, death_jump_hiz);

    }


    void yerControl()

    {

        yerdemi =  Physics2D.OverlapCircle(ZeminPozisyonKontrol.position, ZeminCapKontrol, ZeminKatmanKontrol);

        KarakterAnimator.SetBool("yerdemiymis", yerdemi);
    }

    void Modfonk()
    {
        modalsonuc = BirdahakiZiplanacakZaman % modal1;



    }



}



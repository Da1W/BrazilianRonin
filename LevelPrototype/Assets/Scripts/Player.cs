using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Invector.vCharacterController
{
    public class Player : MonoBehaviour
    {
        public float x;
        public float y;
        public Rigidbody rig;
        public float healthPoints = 3f;
        public Image hp1;
        public Image hp2;
        public Image hp3;

        private bool IsGlide = false;
        private Animator playerAnim;

        private Rigidbody playerBody;

        private vThirdPersonMotor playerMotor;


        private vThirdPersonController playerController;

        void Start()
        {
            playerMotor = GetComponent<vThirdPersonMotor>();
            playerController = GetComponent<vThirdPersonController>();           

            playerBody = GetComponent<Rigidbody>();
            Cursor.visible = false;
            playerAnim = gameObject.GetComponent<Animator>();
        }
        void Update()
        {
            //Debug.Log(playerMotor.groundDistance);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerAnim.SetTrigger("Roll");
                //rig.AddForce(moveDirection * 10, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                playerAnim.SetTrigger("Attack");
            }
            if (Input.GetKeyDown(KeyCode.Mouse1) && playerMotor.groundDistance > 2.5f)
            {
                
                IsGlide = true;
                playerAnim.SetBool("IsGlide", IsGlide);
                playerMotor.freeSpeed.rotationSpeed = 5;
                playerBody.drag = 4;
                playerBody.useGravity = false;
            }
            if (IsGlide && (Input.GetKeyUp(KeyCode.Mouse1) || playerMotor.groundDistance < 0.5f))
            {
                IsGlide = false;
                playerMotor.freeSpeed.rotationSpeed = 15;
                playerAnim.SetBool("IsGlide", IsGlide);
                playerBody.drag = 0;
                playerBody.useGravity = true;
            }

        if (healthPoints < 3)
            {
                hp1.gameObject.SetActive(true);
                hp2.gameObject.SetActive(true);
                hp3.gameObject.SetActive(false);
                if (healthPoints < 2)
                {
                    hp1.gameObject.SetActive(true);
                    hp2.gameObject.SetActive(false);
                    hp3.gameObject.SetActive(false);
                    if (healthPoints < 1)
                    {
                        hp1.gameObject.SetActive(false);
                        playerAnim.SetBool("IsDead", true);
                    }
                }
            }
            else
            {
                hp1.gameObject.SetActive(true);
                hp2.gameObject.SetActive(true);
                hp3.gameObject.SetActive(true);
            }
        }
    }
}

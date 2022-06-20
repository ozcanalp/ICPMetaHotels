using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] PhotonView PV;

    private Vector2 move;
    private Vector3 movement;
    private float walkSpeed = 6f;
    private Rigidbody rigidBody;
    private CapsuleCollider cc;
    private bool isGrounded;
    [SerializeField]private LayerMask groundMask;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();    
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckCapsule(cc.bounds.center, new Vector3(cc.bounds.center.x, cc.bounds.min.y - 0.001f, cc.bounds.center.z), 0.18f, groundMask);
        
        if (this.GetComponent<PlayerMenu>().isMenuOpen)
            return;

        if (PV.IsMine)
        {
            Movements();
        }
    }

    private void Movements()
    {
        movement = transform.right * move.x + transform.forward * move.y;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position + movement * Time.deltaTime * walkSpeed , 0.4f);
        bool canGo = true;
        foreach (var hitCollider in hitColliders)
        {
            Transform current = hitCollider.transform;
            Transform parent = current.parent;
            while (parent != null)
            {
                current = parent;
                parent = current.parent;
            }
            if (current.gameObject.name.Equals("[ENVIRONMENT]"))
            {
                canGo = false;
                break;
            }
        }

        if (canGo)
            rigidBody.MovePosition(transform.position + movement * walkSpeed * Time.deltaTime);
        if (canGo & Input.GetKey(KeyCode.LeftShift))
            rigidBody.MovePosition(transform.position + movement * walkSpeed * 1.5f * Time.deltaTime);


    }
   
}

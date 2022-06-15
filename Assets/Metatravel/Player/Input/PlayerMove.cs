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


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
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

        Collider[] hitColliders = Physics.OverlapSphere(transform.position + movement * Time.deltaTime * walkSpeed
    , 0.4f);
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



    }
    private void Jump()
    {
        rigidBody.AddForce(Vector3.up * 3f, ForceMode.VelocityChange);
    }
}

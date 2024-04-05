using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
public class Controller : MonoBehaviour, IController
{
    [SerializeField] private float speed = 5f;
    [Inject] Player playerControls;
    [Inject] ICoinManager coinManager;
    [Inject] IBiomManager biomManager;
    [SerializeField] float distanceOfCalculation = 0.5f;
    InputAction move;
    Vector2 moveDirection;
    Rigidbody2D body;
    public Player GetPlayerControls() => playerControls;
    void Start()
    {
        playerControls.Enable();
        body = GetComponent<Rigidbody2D>();
        move = playerControls.Movement.Move;
    }
    void FixedUpdate() 
    {
        moveDirection = move.ReadValue<Vector2>();
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, distanceOfCalculation);

        if (hit.collider != null){
            body.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
            //body.MovePosition(new Vector2(moveDirection.x, moveDirection.y) * speed);
        }
        else{
            body.velocity = Vector2.zero;
        }

        //temp logic
        if(moveDirection != Vector2.zero)
        biomManager.SetEncountersAllowance(true);
        else
        biomManager.SetEncountersAllowance(false);
    }
}

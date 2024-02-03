using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{
    private Rigidbody2D _rb;
	private PlayerInput _playerInput;
	private PlayerInputActions _playerInputActions;

	public Transform playersprite;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_playerInputActions = new PlayerInputActions();
		_playerInputActions.Player.Enable();
		_playerInputActions.Player.Jump.performed += Jump;
	}

	private void Update()
	{
		Vector2 inputVector = _playerInputActions.Player.Movement.ReadValue<Vector2>();
		float speed = 5f;
		_rb.velocity = new Vector3(inputVector.x,inputVector.y,0) * speed;
		playersprite.up = _rb.velocity.normalized * -1;
	}

	public void Jump(InputAction.CallbackContext context)
    {
        //print("Jump!" + context.phase);
		if (context.performed)
		{
			
		}
    }

	public void Movement(InputAction.CallbackContext context)
	{
		Vector2 inputVector = context.ReadValue<Vector2>();
		float speed = 5f;
		_rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed);
	}
}

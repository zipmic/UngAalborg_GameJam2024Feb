using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{
    private Rigidbody2D _rb;
	private PlayerInput _playerInput;
	private PlayerInputActions _playerInputActions;
	public float Speed= 10;

	public Transform playersprite;

	public float TotemCooldown = 5;
	private float totemCDcounter;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_playerInputActions = new PlayerInputActions();
		_playerInputActions.Player.Enable();
		_playerInputActions.Player.Place.performed += PlaceTotem;
		
	}

	private void Update()
	{
		Vector2 inputVector = _playerInputActions.Player.Movement.ReadValue<Vector2>();
		
		_rb.velocity = new Vector3(inputVector.x,inputVector.y,0) * Speed;
		playersprite.up = _rb.velocity.normalized * -1;

		totemCDcounter -= Time.deltaTime;
	}

	public GameObject Totem;

	public void PlaceTotem(InputAction.CallbackContext context)
    {
		if (totemCDcounter < 0)
		{
			//print("Jump!" + context.phase);
			if (context.performed)
			{
				GameObject tmp = Instantiate(Totem) as GameObject;
				tmp.transform.position = transform.position;
				totemCDcounter = TotemCooldown;
			}
		}
    }

	public void Movement(InputAction.CallbackContext context)
	{
		Vector2 inputVector = context.ReadValue<Vector2>();
		float speed = 5f;
		_rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed);
	}
}

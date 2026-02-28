using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class MR_PlayerController : MonoBehaviour
{
	[SerializeField]
   	private StarterAssetsInputs starterAssetsInputs; 

	[SerializeField]
	private InputActionReference movementAxis;
	[SerializeField]
	private InputActionReference jumpButton;
	[SerializeField]
	private InputActionReference springTrigger;

	private Vector2 movementVector;
	private bool isJumping;
	private float sprint;

	private void OnEnable()
	{
		movementAxis.action.Enable();
		jumpButton.action.Enable();
		springTrigger.action.Enable();

		movementAxis.action.performed += HandleMovementAxis;
		movementAxis.action.canceled += HandleMovementAxis;

		jumpButton.action.performed += HandleJump;
		jumpButton.action.canceled += HandleEndJump;

		springTrigger.action.performed += HandleSprintTrigger;
		springTrigger.action.canceled += HandleSprintTrigger;

	}

	private void HandleSprintTrigger(InputAction.CallbackContext context)
	{
		SetSprint(context.ReadValue<float>());
	}

	private void HandleEndJump(InputAction.CallbackContext context)
	{
		isJumping = false;
	}

	private void HandleJump(InputAction.CallbackContext context)
	{
		isJumping = true;
	}

	private void HandleMovementAxis(InputAction.CallbackContext context)
	{
		SetMovementVector( context.ReadValue<Vector2>());
	}

	public void SetMovementVector(Vector2 value){
		movementVector = value;
	}

	public void SetIsJumping(bool value){
		isJumping = value;
	}

	public void SetSprint(float value){
		sprint = value;
	}

	private void Update()
	{
		if(starterAssetsInputs == null){
			return;
		}

		starterAssetsInputs.MoveInput(movementVector);
		starterAssetsInputs.JumpInput(isJumping);
		starterAssetsInputs.SprintInput(sprint != 0);
	}

}

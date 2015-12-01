using UnityEngine;
using CnControls;

// This is merely an example, it's for an example purpose only
// Your game WILL require a custom controller scripts, there's just no generic character control systems, 
// they at least depend on the animations

[RequireComponent(typeof(CharacterController))]
public class ThidPersonExampleController : MonoBehaviour
{
    public float MovementSpeed = 10f;

    private Transform _mainCameraTransform;
    private Transform _transform;
    private CharacterController _characterController;

    private void OnEnable()
    {
        _mainCameraTransform = Camera.main.GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    public void Update()
    {
        // Just use CnInputManager. instead of Input. and you're good to go
        var inputVector = new Vector3(0, CnInputManager.GetAxis("Horizontal"),CnInputManager.GetAxis("Vertical"));
        Vector3 movementVector = inputVector;

        // If we have some input
        if (inputVector.sqrMagnitude > 0f)
        {
           // movementVector = _mainCameraTransform.TransformDirection(inputVector);
            //movementVector.y = 0f;
           // movementVector.Normalize();
            _transform.forward = movementVector;
           // transform.Translate(transform.forward * Time.deltaTime * MovementSpeed, Space.World);
        }

        movementVector += Physics.gravity;
        //_characterController.Move(movementVector * Time.deltaTime * MovementSpeed);
    }
}

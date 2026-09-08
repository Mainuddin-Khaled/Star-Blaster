using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float boundaryPadding;
    InputAction moveInput;
    Vector3 moveVector;
    Vector2 minBoundary;
    Vector2 maxBoundary;

    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
        VectorBoundary();
    }

    void Update()
    {
        PlayerMovement();
    }

    void VectorBoundary()
    {
        Camera mainCamera = Camera.main;
        minBoundary = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBoundary = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void PlayerMovement()
    {
        moveVector = moveInput.ReadValue<Vector2>();
        Vector3 newPosition = transform.position + moveVector * moveSpeed * Time.deltaTime;
        newPosition.x = Math.Clamp(newPosition.x, minBoundary.x + boundaryPadding, maxBoundary.x - boundaryPadding);
        newPosition.y = Math.Clamp(newPosition.y, minBoundary.y + boundaryPadding, maxBoundary.y - boundaryPadding);
        transform.position = newPosition;
    }
}

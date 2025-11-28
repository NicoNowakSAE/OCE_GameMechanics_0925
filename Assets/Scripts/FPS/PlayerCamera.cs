using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private Transform playerTrans;
    [SerializeField]
    private Rigidbody playerRB;

    [SerializeField]
    private float mouseSensitivity = 50f;
    Vector2 mouseInput;
    Vector2 rotation;

    [SerializeField]
    private float maxXRotation, minXRotation;

    // Headbob
    [Header("HeadBob")]
    private float defaultYPosition;
    [SerializeField]
    private float speed = 2.39f;
    [SerializeField]
    private float bobHeight = 0.03f;

    private float timer;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        defaultYPosition = transform.localPosition.y;
    }

    void Update()
    {
        GetInput();
    }

    private void LateUpdate()
    {
        rotation.y += mouseInput.x * mouseSensitivity * Time.deltaTime;

        rotation.x -= mouseInput.y * mouseSensitivity * Time.deltaTime;
        rotation.x = Mathf.Clamp(rotation.x, minXRotation, maxXRotation);

        transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        playerTrans.localRotation = Quaternion.Euler(0, rotation.y, 0);

        HandleHeadBob();
    }

    private void HandleHeadBob()
    {
        timer += Time.deltaTime * speed * playerRB.linearVelocity.magnitude;

        transform.localPosition = new Vector3(transform.localPosition.x,
            defaultYPosition + Mathf.Sin(timer) * bobHeight * playerRB.linearVelocity.magnitude, transform.localPosition.z);

        if(playerRB.linearVelocity.magnitude < 0.1f)
        {
            timer = 0;
        }
    }

    void GetInput()
    {
        mouseInput.x = Input.GetAxis("Mouse X");
        mouseInput.y = Input.GetAxis("Mouse Y");
    }
}

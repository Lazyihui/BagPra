using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClientMain : MonoBehaviour {

    ModuleInput moduleInput;

    [SerializeField] RoleEntity roleEntity;

    void Awake() {
        moduleInput = new ModuleInput();
        Debug.Log("ClientMain Awake");
    }

    void Update() {
        float dt = Time.deltaTime;

        Vector3 moveAxis = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            moveAxis.z = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            moveAxis.z = -1;
        }

        if (Input.GetKey(KeyCode.A)) {
            moveAxis.x = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            moveAxis.x = 1;
        }
        // moduleInput.moveAxis = moveAxis;
        roleEntity.Move(moveAxis, dt);

    }
}

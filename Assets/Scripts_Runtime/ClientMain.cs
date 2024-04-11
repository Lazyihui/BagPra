using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClientMain : MonoBehaviour {

    ModuleInput moduleInput;

    ModuleAssets moduleAssets;

    UIApp uiApp;

    [SerializeField] RoleEntity roleEntity;

    [SerializeField] Canvas screenCanvas;

    void Awake() {

        // ==== Phase: Instantiate ====
        moduleInput = new ModuleInput();
        moduleAssets = new ModuleAssets();
        uiApp = new UIApp();
        Debug.Log("ClientMain Awake");


        // ==== Phase: Inject ====
        uiApp.Inject(moduleAssets, screenCanvas);

        // ==== Phase: Init ====
        moduleAssets.Load();

        // ==== Phase: Enter Game ====
        uiApp.Bag_Open(100);
        // 添加物品
        
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

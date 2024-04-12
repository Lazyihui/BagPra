using System;
using UnityEngine;
using UnityEngine.UI;

public class UIApp {
    Canvas screenCanvas;

    Panel_Bag panelBag;

    ModuleAssets assets;

    public Action<int> Bag_OnUseHandle;
    public UIApp() {
        panelBag = new Panel_Bag();
    }

    public void Inject(ModuleAssets assets, Canvas screenCanvas) {
        this.screenCanvas = screenCanvas;
        this.assets = assets;
    }
    // ===== bag =====
    public void Bag_Open(int maxSlot) {
        // maxSlot 用于初始化背包的格子数量
        if (panelBag == null) {
            // 正常来说是要用WorldCanvas的
            GameObject go = Open("Panel_Bag", screenCanvas);
            Panel_Bag bag = go.GetComponent<Panel_Bag>();
            bag.Ctor();
            bag.OnuseHandle = (int id) => {
                Bag_OnUseHandle.Invoke(id);
            };
            this.panelBag = bag;
        }
        panelBag.Init(maxSlot);
    }
    // 背包添加物品
    public void Bag_Add(int id, Sprite icon, int count) {
        panelBag?.Add(id, icon, count);
    }
    public void Bag_Close() {
        panelBag?.Close();
    }

    GameObject Open(string uiName, Canvas canvas) {
        bool has = assets.TryGetUIPrefab(uiName, out GameObject prefab);
        if (!has) {
            Debug.LogError($"UIApp.Open: uiName={uiName} not found");
            return null;
        }
        GameObject go = GameObject.Instantiate(prefab, canvas.transform);
        return go;

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseCannonTurret()
    {
        buildManager.SetTurretToBuild(buildManager.cannonTurretPrefab);
    }

    public void PurchaseStoneTurret()
    {
        buildManager.SetTurretToBuild(buildManager.stoneTurretPrefab);
    }
}

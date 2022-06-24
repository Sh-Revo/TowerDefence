using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint cannonTurret;
    public TurretBlueprint stoneTurret;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectCannonTurret()
    {
        buildManager.SelectTurretToBuild(cannonTurret);
    }

    public void SelectStoneTurret()
    {
        buildManager.SelectTurretToBuild(stoneTurret);
    }
}

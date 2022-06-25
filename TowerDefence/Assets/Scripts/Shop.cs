using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint cannonTurret;
    public TurretBlueprint stoneTurret;
    public TurretBlueprint magicTurret;
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

    public void SelectMagicTurret()
    {
        buildManager.SelectTurretToBuild(magicTurret);
    }
}

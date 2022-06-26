using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text upgradedCost;
    public Button upgradeButton;
    public Text sellAmount;
    private Node _target;

    public void SetTarget(Node target)
    {
        _target = target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradedCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradedCost.text = "Done";
            upgradeButton.interactable = false;
        }
        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}

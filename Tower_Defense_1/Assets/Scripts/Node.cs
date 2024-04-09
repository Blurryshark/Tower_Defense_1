using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    public Color notEnoughMoneyColor;
    private Renderer rend;
    public Vector3 positionOffset;
    public GameObject buildEffect;
    
    
    [HideInInspector]
    public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;

    private BuildManager _buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        _buildManager = BuildManager.instance;
    }

    public Vector3 GetBuiltPostion()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (turret != null)
        {
            _buildManager.selectNode(this);
            return;
        }

        BuildTurret(BuildManager.getTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuiltPostion(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildEffect, GetBuiltPostion(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
                {
                    return;
                }
        
                PlayerStats.Money -= turretBlueprint.upgradeCost;

                Destroy(turret); 
                
                GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuiltPostion(), Quaternion.identity);
                turret = _turret;
        
                GameObject effect = (GameObject)Instantiate(buildEffect, GetBuiltPostion(), Quaternion.identity);
                Destroy(effect, 5);

                isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        
        GameObject effect = (GameObject)Instantiate(buildEffect, GetBuiltPostion(), Quaternion.identity);
        Destroy(effect, 5);
        
        Destroy(turret);
        turretBlueprint = null;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!_buildManager.CanBuild)
        {
            return;
        }

        if (_buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

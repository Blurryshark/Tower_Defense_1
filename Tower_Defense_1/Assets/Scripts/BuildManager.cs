using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build manager!");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    private TurretBlueprint turretToBuild;
    
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public bool CanBuild
    {
        get { return turretToBuild != null; }
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuiltPostion(), Quaternion.identity);
        node.turret = turret;
    }
}

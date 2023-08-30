using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Weapon Type", menuName = "Weapon")]
public class Weapon_Type : ScriptableObject
{
    public GameObject weaponPrefab;
    public string typeName;
    public int magazineCapacity;
    public int maxMagazineAmount;
    public bool automaticRifle;
    public int currentMagAmount;
    public int damage;
}

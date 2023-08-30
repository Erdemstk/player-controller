using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform weaponSlot;
    private GameObject currentWeapon;
    [SerializeField] private Weapon_Type equippedWeapon;

    private void Start()
    {
        
    }
    public void EquipWeapon(Weapon_Type weaponType)
    {
        equippedWeapon = weaponType;
        if(currentWeapon != null)
        {
            Destroy(currentWeapon);
        }
        currentWeapon = Instantiate(weaponType.weaponPrefab, weaponSlot);
        Debug.Log(currentWeapon.name);
        currentWeapon.transform.SetParent(weaponSlot);
        currentWeapon.transform.position = Vector3.zero;
        //UI_Manager.Instance.magCap_UI.text = currentWeapon.GetComponent<Weapon>().magCapacity.ToString();
    }




}

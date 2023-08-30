using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Weapon_Type weaponType;

    string typeName;
    public int magCapacity;
    int maxMagAmount;
    int currentMagAmount;
    bool autoRifle;
    

    private static Weapon instance = null;

    public static Weapon Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Weapon>();
            }
            return instance;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        WeaponManager weaponManager = other.GetComponent<WeaponManager>();
        if (weaponManager != null)
        {
            weaponManager.EquipWeapon(weaponType);
        }
        Destroy(gameObject);
      
      
    }
    void Start()
    {
        Start_Info();
        Debug.Log(magCapacity);
    }

    // Update is called once per frame
    void Update()
    {
        //UI_Manager.Instance.magCap_UI.text = weaponType.magazineCapacity.ToString();
        //UI_Manager.Instance.magAmount_UI.text = currentMagAmount.ToString();
    }
    void Fire()
    {
       
        if (!autoRifle)
        {
            if(magCapacity > 0)
            {
                StartCoroutine("SingleFire");
            }
            else
            {

            }
        }
 
        
    }
    void Reload()
    {
        
    }
    void Start_Info()
    {
        string typeName = weaponType.typeName;
        int magCapacity = weaponType.magazineCapacity;
        int maxMagAmount = weaponType.maxMagazineAmount;
        bool autoRifle = weaponType.automaticRifle;
        int currentMagAmount = weaponType.currentMagAmount;
    }
    IEnumerator SingleFire()
    {
        magCapacity -= 1;
        yield return new WaitForSeconds(1);
    }
    
}



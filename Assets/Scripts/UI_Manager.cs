using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public Image HeavyGunImage;
    public Image HandGunImage;
    public Image ProjectileImage;
    public Image currentImage;

     Text magCap_UI;
    public Text magAmount_UI;

    public Sprite[] sprites;

    Vector3 currentScale;
   

    private static UI_Manager instance = null;

    public static UI_Manager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UI_Manager>();
            }
            return instance;
        }
    }
    void Start()
    {
        currentScale = currentImage.transform.localScale;
        Game_Starting();
    }
    void Update()
    {
       
        UI_Contollers();
        //magCap_UI.text = GetComponent<Weapon_Type>().magazineCapacity.ToString(); OLMUYYOOOORRRRRR
    }
    void UI_Contollers()
    {
        //HeavyGun
        if (Input.GetKey(KeyCode.Alpha1))
        {
            HeavyGunImage.enabled = true;
            HandGunImage.enabled = false;
            ProjectileImage.enabled = false;
            Image heavyImage = HeavyGunImage.GetComponent<Image>();
            heavyImage.sprite = sprites[1];
            currentImage.sprite = heavyImage.sprite;
            currentImage.transform.localScale = currentScale;
        }
        //HandGun
        if (Input.GetKey(KeyCode.Alpha2))
        {
            HandGunImage.enabled = true;
            HeavyGunImage.enabled=false;
            ProjectileImage.enabled = false;
            Image handGunImage = HandGunImage.GetComponent<Image>();
            handGunImage.sprite = sprites[0];
            currentImage.sprite = handGunImage.sprite;
            currentImage.transform.localScale = currentScale;
        }
        //Projectile
        if (Input.GetKey(KeyCode.Alpha3))
        {
            ProjectileImage.enabled= true;
            HeavyGunImage.enabled = false;
            HandGunImage.enabled = false;
            Image projectileImage = ProjectileImage.GetComponent<Image>();
            projectileImage.sprite = sprites[2];
            currentImage.sprite = projectileImage.sprite;
            currentImage.transform.localScale = new Vector3(1.5f,1.5f,0);
        }
    }
    void Game_Starting()
    {
        HandGunImage = HandGunImage.GetComponent<Image>();
        HandGunImage.enabled = true;
        HandGunImage.sprite = sprites[0];
        currentImage = currentImage.GetComponent<Image>();
        currentImage.enabled = true;
        currentImage.sprite= HandGunImage.sprite;
    }
    
    



}

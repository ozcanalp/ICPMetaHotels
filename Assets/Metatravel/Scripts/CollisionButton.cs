using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Sýnýfýn Açýlma sebebi: ArtGalleryde gezerken Fotonun önüne geldiðinde fotoyu beðenirsek ve almak istersek diye 
 *                        bir tane button çýkarýcak websitesine gidebilsin diye.
 *                     
 * Yardýmcý Sýnýflarý: CursorHide --> Mouse lazým butona týklamak için Oraya kod eklendi Update içine Runtime da mouseu aç kapa yapmak için.
 *                     BookManager --> Url yi butona verip OnClickten gidiyoruz.
 */
public class CollisionButton : MonoBehaviour
{

    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Start()
    {
        // Playe basýnca Bug oldu button gözüküyodu direkt ,Startta kapatýyoz çok önemli biþey deðil.
        OnDisable();
    }
    
    /**
     Collisiona ilk giriþ yapýldýðýnda butonu active etsin  
     */
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            OnEnable();
            Debug.Log("Entered");
        }
    }

    /**
     Collisionu saðlamaya devam ettiði sürece Buttonu Active tutucak
     */
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnEnable();
            //Debug.Log("Staying");
        }
    }

    /**
     Collision olmuþ objeden dýþarý çýkýnca buttonu deActive edicek
     */
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnDisable();
            Debug.Log("Exited");
        }
    }
    /**
    Buttonu görünür yapýcak
     */
    private void OnEnable()
    {
        button.gameObject.SetActive(true);
    }
    /**
     Butonu görünmez yapýcak
     */
    private void OnDisable()
    {
        button.gameObject.SetActive(false);
    }
}

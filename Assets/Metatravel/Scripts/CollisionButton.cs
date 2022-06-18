using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * S�n�f�n A��lma sebebi: ArtGalleryde gezerken Fotonun �n�ne geldi�inde fotoyu be�enirsek ve almak istersek diye 
 *                        bir tane button ��kar�cak websitesine gidebilsin diye.
 *                     
 * Yard�mc� S�n�flar�: CursorHide --> Mouse laz�m butona t�klamak i�in Oraya kod eklendi Update i�ine Runtime da mouseu a� kapa yapmak i�in.
 *                     BookManager --> Url yi butona verip OnClickten gidiyoruz.
 */
public class CollisionButton : MonoBehaviour
{

    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Start()
    {
        // Playe bas�nca Bug oldu button g�z�k�yodu direkt ,Startta kapat�yoz �ok �nemli bi�ey de�il.
        OnDisable();
    }
    
    /**
     Collisiona ilk giri� yap�ld���nda butonu active etsin  
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
     Collisionu sa�lamaya devam etti�i s�rece Buttonu Active tutucak
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
     Collision olmu� objeden d��ar� ��k�nca buttonu deActive edicek
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
    Buttonu g�r�n�r yap�cak
     */
    private void OnEnable()
    {
        button.gameObject.SetActive(true);
    }
    /**
     Butonu g�r�nmez yap�cak
     */
    private void OnDisable()
    {
        button.gameObject.SetActive(false);
    }
}

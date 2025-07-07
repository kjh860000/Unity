using UnityEditor.PackageManager.UI;
using UnityEngine;

public class CatChoose : MonoBehaviour
{
    public enum CatType { Cat1, Cat2, Cat3, Cat4, Cat5, Cat6 }
    public CatType catType;

    public GameObject cat1;
    public GameObject cat2;
    public GameObject cat3;
    public GameObject cat4;
    public GameObject cat5;
    public GameObject cat6;

    public void SetCat()
    {
        switch (catType)
        {
            case CatType.Cat1:
                cat1.SetActive(true);
                cat2.SetActive(false);
                cat3.SetActive(false);
                cat4.SetActive(false);
                cat5.SetActive(false);
                cat6.SetActive(false);
                break;
            case CatType.Cat2:
                cat1.SetActive(false);
                cat2.SetActive(true);
                cat3.SetActive(false);
                cat4.SetActive(false);
                cat5.SetActive(false);
                cat6.SetActive(false);
                break;
            case CatType.Cat3:
                cat1.SetActive(false);
                cat2.SetActive(false);
                cat3.SetActive(true);
                cat4.SetActive(false);
                cat5.SetActive(false);
                cat6.SetActive(false);
                break;
            case CatType.Cat4:
                cat1.SetActive(false);
                cat2.SetActive(false);
                cat3.SetActive(false);
                cat4.SetActive(true);
                cat5.SetActive(false);
                cat6.SetActive(false);
                break;
            case CatType.Cat5:
                cat1.SetActive(false);
                cat2.SetActive(false);
                cat3.SetActive(false);
                cat4.SetActive(false);
                cat5.SetActive(true);
                cat6.SetActive(false);
                break;
            case CatType.Cat6:
                cat1.SetActive(false);
                cat2.SetActive(false);
                cat3.SetActive(false);
                cat4.SetActive(false);
                cat5.SetActive(false);
                cat6.SetActive(true);
                break;
        }
    }
}


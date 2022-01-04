using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBox : MonoBehaviour
{
    public GameObject nextShowObj;
    public int myId;
    [SerializeField] GameObject boxTxtBuyLand;
    [SerializeField] GameObject boxTxtHarvest;
    [SerializeField] GameObject swipeToMove;
    

    public List<ActiveUI> Enable = new List<ActiveUI>();
    public List<ActiveUI> Disable = new List<ActiveUI>();

    private void OnEnable()
    {
        switch(myId)
        {
            case 0:
                boxTxtBuyLand.SetActive(true);
                boxTxtHarvest.SetActive(false);
                break;
            case 1:
                boxTxtHarvest.SetActive(true);
                boxTxtBuyLand.SetActive(false);
                break;
        }

        foreach (var item in Enable)
        {
            item.Obj.SetActive(item.Active);
        }
    }

    private void OnDisable()
    {
        switch (myId)
        {
            case 0:
                boxTxtBuyLand.SetActive(false);
                swipeToMove.SetActive(false);
                break;
            case 1:
                boxTxtHarvest.SetActive(false);
                break;
        }

        foreach (var item in Disable)
        {
            if(item != null && item.Obj) item.Obj.SetActive(item.Active);
        }
    }

    public void Set()
    {
        if (DataSaveManager.S.General.indexTut != myId)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnOpenSuccess();
        }
    }

    public void OnOpenSuccess()
    {
        DataSaveManager.S.General.indexTut++;
        gameObject.SetActive(false);
        if(nextShowObj) nextShowObj.SetActive(true);
    }

    [System.Serializable]
    public class ActiveUI
    {
        public bool Active;
        public GameObject Obj;
    }
}

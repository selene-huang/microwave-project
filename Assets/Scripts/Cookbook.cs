using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookbook : MonoBehaviour
{

    #region Page Metadata Variables
    private int currPage;
    private int totalPages;
    private int totalItems;
    private int itemsPerPage = 6;
    #endregion

    #region Game Object Variables
    private GameManager gm;
    private GameObject backButton;
    private GameObject nextButton;
    private GameObject leftGrid;
    private GameObject rightGrid;
    #endregion

    #region Unity Functions
    void Start()
    {
        this.gameObject.SetActive(false);
        backButton = this.gameObject.transform.Find("BackButton").gameObject;
        nextButton = this.gameObject.transform.Find("NextButton").gameObject;
        leftGrid = this.gameObject.transform.Find("LeftGrid").gameObject;
        rightGrid = this.gameObject.transform.Find("RightGrid").gameObject;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        totalItems = gm.GetNumItems();
        totalPages = (int) System.Math.Ceiling(1.0 * totalItems / itemsPerPage);
    }
    #endregion

    #region Book Functions
    public void OpenBook()
    {
        this.gameObject.SetActive(true);
        backButton.SetActive(false);
        currPage = 0;
    }

    public void CloseBook()
    {
        this.gameObject.SetActive(false);
    }

    public void NextPage()
    {
        currPage += 2;
        if (currPage >= totalPages)
        {
            nextButton.SetActive(false);
        } else if (currPage > 0)
        {
            backButton.SetActive(true);
        }
    }

    public void PrevPage()
    {
        currPage -= 2;
        if (currPage == 0)
        {
            backButton.SetActive(false);
        }  else if (currPage < totalPages)
        { 
            nextButton.SetActive(true); 
        }
    }

    private void PopulatePages()
    {
        for (int i = 0; i < itemsPerPage * 2; i++)
        {

        }
    }
    #endregion
}

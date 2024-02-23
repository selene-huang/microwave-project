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
    private Transform leftGrid;
    private Transform rightGrid;

    private List<CookbookItem> displayItemList;

    [SerializeField]
    [Tooltip("Object used to display each item")]
    private CookbookItem cookbookItem;
    #endregion

    #region Unity Functions
    void Start()
    {
        this.gameObject.SetActive(false);
        backButton = this.gameObject.transform.Find("BackButton").gameObject;
        nextButton = this.gameObject.transform.Find("NextButton").gameObject;

        leftGrid = this.gameObject.transform.Find("LeftGrid");
        rightGrid = this.gameObject.transform.Find("RightGrid");
        displayItemList = new List<CookbookItem>();

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
        foreach (CookbookItem i in displayItemList)
        {
            Destroy(i);
        }
        displayItemList.Clear();

        Transform currGrid = leftGrid;
        for (int i = 0; i < itemsPerPage * 2; i++)
        {
            int itemIndex = currPage * itemsPerPage + i;
            if (itemIndex >= totalItems)
            {
                break;
            } else if (i == itemsPerPage)
            {
                currGrid = rightGrid;
            }

            ItemInfo currItem = gm.GetItem(itemIndex);
            CookbookItem newItem = Instantiate(cookbookItem, currGrid);

            
            displayItemList.Add(newItem);
        }
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookbook : MonoBehaviour
{

    #region Page Metadata Variables
    private int currPage;
    private int totalPages;
    private int totalItems;
    private int itemsPerPage = 6;
    [SerializeField]
    [Tooltip("Sprite for unknown items")]
    private Sprite unknownSprite;
    #endregion

    #region Game Object Variables
    private GameManager gm;
    private GameObject backButton;
    private GameObject nextButton;
    private Button cookbookButton;
    private Transform leftGrid;
    private Transform rightGrid;
    #endregion

    #region Unity Functions
    void Start()
    {
        this.gameObject.SetActive(false);

        backButton = this.gameObject.transform.Find("BackButton").gameObject;
        nextButton = this.gameObject.transform.Find("NextButton").gameObject;
        cookbookButton = GameObject.FindWithTag("CookbookButton").GetComponent<Button>();

        leftGrid = this.gameObject.transform.Find("LeftGrid");
        rightGrid = this.gameObject.transform.Find("RightGrid");

        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        totalItems = gm.GetNumItems();
        totalPages = (int) System.Math.Ceiling(1.0 * totalItems / itemsPerPage);
    }
    #endregion

    #region Book Functions
    public void OpenBook()
    {
        this.gameObject.SetActive(true);
        currPage = 0;
        PopulatePages();
        cookbookButton.interactable = false;
    }

    public void CloseBook()
    {
        this.gameObject.SetActive(false);
        cookbookButton.interactable = true;
    }

    public void NextPage()
    {
        currPage += 2;
        PopulatePages();
    }

    public void PrevPage()
    {
        currPage -= 2;
        PopulatePages();
    }

    private void PopulatePages()
    {
        backButton.SetActive(currPage != 0);
        nextButton.SetActive(currPage + 1 < totalPages);

        for (int i = 0; i < itemsPerPage; i++)
        {
            int itemIndex = currPage * itemsPerPage + i;
            if (itemIndex >= totalItems)
            {
                leftGrid.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                ItemInfo currItem = gm.GetItem(itemIndex);
                GameObject currDisplay = leftGrid.GetChild(i).gameObject;
                CookbookItem currDisplayItem = (CookbookItem)currDisplay.GetComponent("CookbookItem");

                if (currItem.IsDiscovered) { 
                    currDisplayItem.SetSprite(currItem.Sprite);
                    currDisplayItem.SetName(currItem.Name);
                } else {
                    currDisplayItem.SetSprite(unknownSprite);
                    currDisplayItem.SetName("???");
                }

                leftGrid.GetChild(i).gameObject.SetActive(true);
            }
        }
        for (int i = 0; i < itemsPerPage; i++)
        {
            int itemIndex = (currPage + 1) * itemsPerPage + i;
            if (itemIndex >= totalItems)
            {
                rightGrid.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                ItemInfo currItem = gm.GetItem(itemIndex);
                GameObject currDisplay = rightGrid.GetChild(i).gameObject;
                CookbookItem currDisplayItem = (CookbookItem)currDisplay.GetComponent("CookbookItem");

                if (currItem.IsDiscovered) { 
                    currDisplayItem.SetSprite(currItem.Sprite);
                    currDisplayItem.SetName(currItem.Name);
                } else {
                    currDisplayItem.SetSprite(unknownSprite);
                    currDisplayItem.SetName("???");
                }
                
                rightGrid.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    #endregion
}

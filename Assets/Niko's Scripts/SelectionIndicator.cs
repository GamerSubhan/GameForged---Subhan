using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionIndicator : MonoBehaviour
{
    [SerializeField] Transform selectionIndicatorCircle;
    SelectionManager _selectionManager;

    void Start()
    {
        _selectionManager = FindObjectOfType<SelectionManager>();
    }


    void Update()
    {
        var selectedGameObject = _selectionManager.selectedGameObject;
        if (selectedGameObject == null) return;

        selectionIndicatorCircle.position = selectedGameObject.transform.position;

        if (selectedGameObject.layer == 9)
        {
            DisplaySlectionIndicator(Color.green);
        }
        else if (selectedGameObject.layer == 6)
        {
            DisplaySlectionIndicator(Color.red);
        }
    }

    private void DisplaySlectionIndicator(Color c)
    {
        selectionIndicatorCircle.gameObject.SetActive(true);
        selectionIndicatorCircle.gameObject.GetComponentInChildren<Image>().color = c;
    }

    public void ClearSelection()
    {
        selectionIndicatorCircle.gameObject.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] LayerMask groundMask;
    [SerializeField] string selectableTag = "Selectable";
    public GameObject selectedGameObject;
    private SelectionIndicator _indicator;

    private void Start()
    {
        _indicator = FindObjectOfType<SelectionIndicator>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hasHit && hit.collider.gameObject.tag == selectableTag)
        {
            GameObject hitObject = hit.transform.root.gameObject;

            SelectObject(hitObject);
        }
        else
        {
            selectedGameObject = null;
            _indicator.ClearSelection();
        }
    }

    private void SelectObject(GameObject hitObject)
    {
        if (selectedGameObject != null)
        {
            if (hitObject == selectedGameObject)
            {
                return;
            }
            ClearSelection();
        }
        selectedGameObject = hitObject;
    }

    private void ClearSelection()
    {
        selectedGameObject = null;
    }
}

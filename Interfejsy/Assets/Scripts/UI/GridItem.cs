using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridItem : MonoBehaviour {

    [SerializeField] private UnityEvent onClick;
    [SerializeField] private UnityEvent onSelect;
    [SerializeField] private UnityEvent onDisselect;
    [SerializeField] private UnityEvent onDetailClick;

    virtual public void Click() {
        onClick?.Invoke();
    }

    virtual public void Select() {
        onSelect?.Invoke();
    }

    virtual public void Disselect() {
        onDisselect?.Invoke();
    }

    virtual public void DetailClick() {
        onDetailClick?.Invoke();
    }
}

using UnityEngine;
using UnityEngine.Events;

public class DanceController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _OnSelectDance;

    [SerializeField]
    private UnityEvent _onDanceSelected;

    public void ActivateSelectDance()
    {
        _OnSelectDance?.Invoke();
    }
    public void onSelectedDance()
    {
        _onDanceSelected?.Invoke();
    }
}

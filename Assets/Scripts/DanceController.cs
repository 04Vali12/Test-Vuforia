using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DanceController : MonoBehaviour
{
    [SerializeField]
    private Animator _characterAnimator;

    [SerializeField]
    private NotesManager _notesManager;

    [SerializeField]
    private UnityEvent _OnSelectDance;

    [SerializeField]
    private UnityEvent _onDanceSelected;
    [SerializeField]

    private string _failAnimationName = "Fail";

    private SoundData _currentSoundData;

    public void ActivateSelectDance()
    {
        _OnSelectDance?.Invoke();
    }
    public void onSelectedDance(SoundData soundData)
    {
        _currentSoundData = soundData;
        _onDanceSelected?.Invoke();
    }

    public void StartDance()
    {
        _characterAnimator.Play(_currentSoundData.animationName);
        SoundManager.instance.PlayMusic(_currentSoundData.musicName);
        _notesManager.StartNoteChart(_currentSoundData.notesConfig, _currentSoundData.speed);

    }
    public void FailedNote()
    {
        StartCoroutine(ResetDance());
    }

    public IEnumerator ResetDance()
    {
        _characterAnimator.Play(_failAnimationName);
        float failAnimationLength = _characterAnimator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(failAnimationLength);
        _characterAnimator.Play(_currentSoundData.animationName);
    }
    
}

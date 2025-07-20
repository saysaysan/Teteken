using DG.Tweening;
using UnityEngine;

/// <summary>
/// Initializes DOTween with game-specific settings before any scene loads.
/// </summary>
public class DOTweenInit : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        // Enable safe mode to automatically handle possible tween errors
        DOTween.useSafeMode = true;

        // Initialize DOTween (disable recycle, enable default logging)
        DOTween.Init(recycleAllByDefault: false, useSafeMode: true, logBehaviour: LogBehaviour.Default);

        // Set global defaults that fit the game's style
        DOTween.defaultEaseType = Ease.Linear;
        DOTween.defaultAutoPlay = AutoPlay.None;
        DOTween.defaultRecyclable = true;
    }
}

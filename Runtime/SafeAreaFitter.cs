using UnityEngine;

namespace GameDev.UnityCommon
{
    /// <summary>
    /// Fits this RectTransform to Screen.safeArea, keeping UI out of
    /// notches/cutouts/rounded corners/home indicators. Re-applies
    /// automatically when the safe area changes (e.g. on orientation
    /// change) -- there's no built-in Unity event for that, so this just
    /// cheaply compares against the last known value every frame.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Rect _lastSafeArea;
        private ScreenOrientation _lastOrientation;

        private void Awake()
        {
            _rectTransform = (RectTransform)transform;
            Apply();
        }

        private void Update()
        {
            if (Screen.safeArea != _lastSafeArea || Screen.orientation != _lastOrientation)
            {
                Apply();
            }
        }

        private void Apply()
        {
            _lastSafeArea = Screen.safeArea;
            _lastOrientation = Screen.orientation;

            var anchorMin = _lastSafeArea.position;
            var anchorMax = _lastSafeArea.position + _lastSafeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
        }
    }
}

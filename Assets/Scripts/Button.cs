using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler {
    private bool _on;
    private Animator _animator;
    private LoadSprites _spriteLoader;

    void Start() {
        _animator = GetComponent<Animator>();
        _spriteLoader = GameObject.Find("Panel").GetComponent<LoadSprites>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("Click");
        _on = true;
        HandleClick();
    }

    private void HandleClick() {
        if (_on) {
            _animator.SetBool("anim", true);
            _spriteLoader.Load();
        }
    }
}
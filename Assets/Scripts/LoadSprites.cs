using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadSprites : MonoBehaviour {
    [SerializeField] private GameObject[] _spriteRenderers;
    [SerializeField] private string[] _addressableKeys;

    public void Load() {
        for (int i = 0; i < _spriteRenderers.Length; i++) {
            StartCoroutine(LoadSprite(_spriteRenderers[i].GetComponent<SpriteRenderer>(), i));
        }
    }

    private IEnumerator LoadSprite(SpriteRenderer spriteRenderer, int index) {
        AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(_addressableKeys[index]);

        yield return handle;

        if (handle.Status == AsyncOperationStatus.Succeeded) {
            spriteRenderer.sprite = handle.Result;
        }
    }
}

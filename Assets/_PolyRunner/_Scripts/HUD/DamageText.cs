using TMPro;
using UnityEngine;

namespace PolyRunner.HUD
{
    public class DamageText : MonoBehaviour
    {
        private GameObject _textPrefab;

        private void Start()
        {
            _textPrefab = (GameObject)Resources.Load("DamageText");
        }

        public void Setup(float damage, Vector3 position, Color color)
        {
            GameObject textGameObject = Instantiate(_textPrefab);

            SetTextVisual(damage, color, textGameObject);
            SetTextPosition(position, textGameObject);

            textGameObject.SetActive(true);
            Destroy(textGameObject, 2.5f);
        }

        private void SetTextPosition(Vector3 position, GameObject textGameObject)
        {
            Vector3 positionOffset = new(0f, 2f, -0.2f);
            Vector3 lookAtOffset = transform.position - Camera.main.transform.position;
            
            textGameObject.transform.position = position + positionOffset;
            textGameObject.transform.LookAt(Camera.main.transform.position + lookAtOffset);
        }

        private void SetTextVisual(float damage, Color color, GameObject textGameObject)
        {
            TextMeshProUGUI textMeshProUGUI = textGameObject.GetComponentInChildren<TextMeshProUGUI>();
            textMeshProUGUI.color = color;
            textMeshProUGUI.text = $"-{damage:F0}";
        }
    }
}
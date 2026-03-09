using UnityEngine;
using UnityEngine.UI;

public class FogScript : MonoBehaviour
{
    [SerializeField] private Vector2Int size;
    [SerializeField] private Color color;
    [SerializeField] private float innerRadius, outerRadius;
    [SerializeField, Range(0f, 1f)] private float minAlpha, maxAlpha;

    private Texture2D texture;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void GenerateTexture()
    {
        texture = new(size.x, size.y);
        Vector2 center = new(size.x / 2f, size.y / 2f);

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                float dist = Vector2.Distance(new Vector2(x, y), center);
                float alpha = Mathf.Clamp(Mathf.InverseLerp(innerRadius, outerRadius, dist), minAlpha, maxAlpha);
                texture.SetPixel(x, y, new(color.r, color.g, color.b, alpha * color.a));
            }
        }

        texture.Apply();

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, size.x, size.y), new Vector2(0.5f, 0.5f));
        image.sprite = sprite;
    }
}

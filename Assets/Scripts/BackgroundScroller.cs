using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
	[SerializeField] float ScrollSpeed = 0.2f;
	[SerializeField] Material Background;

    // Update is called once per frame
    void Update()
    {
		Background.mainTextureOffset += Vector2.up * ScrollSpeed * Time.deltaTime;
    }
}

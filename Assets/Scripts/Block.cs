using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int maxHits;
    [SerializeField] private int timesHit;

    private Level _level;
    private Score _status;


    private void Start()
    {
        if (gameObject.CompareTag("Unbreakable"))
            return;
        spriteRenderer = GetComponent<SpriteRenderer>();
        _level = FindObjectOfType<Level>();
        _status = FindObjectOfType<Score>();
        _level.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Unbreakable"))
            return;
        timesHit++;
        if (timesHit >= maxHits)
            DestroyBlock();
        else
        {
            spriteRenderer.sprite = sprites[timesHit - 1];
        }
    }

    private void DestroyBlock()
    {
        GameObject o = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(o, 1f);
        _status.AddToScore();
        _level.DeleteBlock();
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Destroy(gameObject);
    }
}

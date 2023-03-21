using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle;
    [SerializeField] private AudioClip[] clips;

    private Rigidbody2D _ballRb;
    private AudioSource _audioSource;
    private Vector3 _offset;
    private bool _isPunched;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _ballRb = GetComponent<Rigidbody2D>();
        _offset = transform.position - paddle.transform.position;
    }


    void Update()
    {
        if (_isPunched)
            return;
        transform.position = paddle.transform.position + _offset;
        if (Input.GetMouseButtonDown(0))
        {
            _ballRb.velocity = new Vector2(Random.Range(-3f, 3f), 10f);
            _isPunched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}

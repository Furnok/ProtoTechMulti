using Sirenix.OdinInspector;
using UnityEngine;

public class S_Goal : MonoBehaviour
{
    [Title("Parameters")]
    [SerializeField] private TagsName tagBall;

    [Title("RSE")]
    [SerializeField] private RSE_Goal rseGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagBall.ToString()))
        {
            rseGoal?.RaiseEvent();
        }
    }
}
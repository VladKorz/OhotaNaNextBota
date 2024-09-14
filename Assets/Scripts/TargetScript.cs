using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public int hp;
    public bool isHit = false;

    [Header("Анимации")]
    public AnimationClip targetHit;
    private Animator animator;

    [Header("Префабы")]
    public Transform explosionPrefab;
    public GameObject existingObject; // Существующий объект, от которого будем брать позицию и поворот

    private void Awake()
    {
        // Получаем компонент Animator
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Если объект был поражен
        if (isHit == true)
        {
            hp--;
            isHit = false;
            animator.SetTrigger("Play");
        }
        if (hp <= 0)
        {
            // Получаем позицию и поворот существующего объекта
            Vector3 spawnPosition = existingObject.transform.position;
            Quaternion spawnRotation = existingObject.transform.rotation;

            // Спавним префаб
            Instantiate(explosionPrefab, spawnPosition, spawnRotation);

            Destroy(gameObject);
         }
        
    }

}
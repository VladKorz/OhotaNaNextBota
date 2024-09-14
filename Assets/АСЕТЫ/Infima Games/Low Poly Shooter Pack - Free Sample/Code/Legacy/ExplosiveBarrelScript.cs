using UnityEngine;
using System.Collections;

public class ExplosiveBarrelScript : MonoBehaviour
{

    float randomTime;
    bool routineStarted = false;

    // Используется для проверки, была ли бочка
    // поражена и должна взорваться
    public bool explode = false;

    [Header("Префабы")]
    // Префаб взрыва
    public Transform explosionPrefab;
    // Префаб уничтоженной бочки
    public Transform destroyedBarrelPrefab;

    [Header("Настраиваемые опции")]
    // Минимальное время до взрыва бочки
    public float minTime = 0.05f;
    // Максимальное время до взрыва бочки
    public float maxTime = 0.25f;

    [Header("Опции взрыва")]
    // Радиус поражения взрыва
    public float explosionRadius = 12.5f;
    // Мощность взрыва
    public float explosionForce = 4000.0f;

    private void Update()
    {
        // Генерируем случайное время в зависимости от минимального и максимального значений
        randomTime = Random.Range(minTime, maxTime);

        // Если бочка поражена
        if (explode == true)
        {
            if (routineStarted == false)
            {
                // Запускаем корутину взрыва
                StartCoroutine(Explode());
                routineStarted = true;
            }
        }
    }

    private IEnumerator Explode()
    {
        // Ждем заданное время
        yield return new WaitForSeconds(randomTime);

        // Спавним префаб уничтоженной бочки
        Instantiate(destroyedBarrelPrefab, transform.position,
                     transform.rotation);

        // Сила взрыва
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            // Добавляем силу к близлежащим жестким телам
            if (rb != null)
                rb.AddExplosionForce(explosionForce * 50, explosionPos, explosionRadius);

            // Если взрыв бочки поражает другие бочки с тегом "ExplosiveBarrel"
            if (hit.transform.tag == "ExplosiveBarrel")
            {
                // Включаем bool explode для объекта взрывной бочки
                hit.transform.gameObject.GetComponent<ExplosiveBarrelScript>().explode = true;
            }

            // Если взрыв поражает тег "Target"
            if (hit.transform.tag == "Target")
            {
                // Включаем bool isHit для объекта цели
                hit.transform.gameObject.GetComponent<TargetScript>().isHit = true;
            }

            // Если взрыв поражает тег "GasTank"
            if (hit.GetComponent<Collider>().tag == "GasTank")
            {
                // Если газовый баллон находится в радиусе, взрываем его
                hit.gameObject.GetComponent<GasTankScript>().isHit = true;
                hit.gameObject.GetComponent<GasTankScript>().explosionTimer = 0.05f;
            }
        }

        // Выполняем raycast вниз, чтобы проверить тег земли
        RaycastHit checkGround;
        if (Physics.Raycast(transform.position, Vector3.down, out checkGround, 50))
        {
            // Спавним префаб взрыва в точке попадания
            Instantiate(explosionPrefab, checkGround.point,
              Quaternion.FromToRotation(Vector3.forward, checkGround.normal));
        }

        // Уничтожаем текущий объект бочки
        Destroy(gameObject);
    }
}
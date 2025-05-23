using UnityEngine;

public class MatikanLight : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D light2D;
    private float waktuMenunggu = 15f;
    private float waktuSekarang = 0f;
    private bool sudahDimatikan = false;
    private float intensitasAwal;
    private float intensitasMinimum = 0.1f;

    void Start()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        if (light2D == null)
        {
            Debug.LogError("Komponen Light2D tidak ditemukan pada objek ini.");
        }

        intensitasAwal = light2D.intensity;
    }

    void Update()
    {
        if (light2D != null && !sudahDimatikan)
        {
            waktuSekarang += Time.deltaTime;

            if (waktuSekarang >= waktuMenunggu)
            {
                light2D.enabled = false;
                sudahDimatikan = true;
            }
            else
            {
                float lerpedIntensity = Mathf.Lerp(intensitasAwal, intensitasMinimum, waktuSekarang / waktuMenunggu);
                light2D.intensity = lerpedIntensity;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CircleCollider2D circleCollider = other.GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            light2D.enabled = true;
            sudahDimatikan = false;
            waktuSekarang = 0f;
        }
    }
}

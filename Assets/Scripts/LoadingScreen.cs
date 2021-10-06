using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] public GameObject screen;
    [SerializeField] public string sceneToLoad;

    public void LoadSceneAsync()
    {
        StartCoroutine(LoadSceneCoroutine());
    }

    IEnumerator LoadSceneCoroutine()
    {
        // Instance de l'objet à charger
        var instance = Instantiate(screen);

        // Ne pas détruire l'objet pendant le chargement
        DontDestroyOnLoad(screen);

        // Sène à charger
        var loading = SceneManager.LoadSceneAsync(sceneToLoad);

        // Refuser l'activation
        loading.allowSceneActivation = false;

        // On vérifie si le chergement est terminé
        while (loading.isDone == false)
        {
            // Si le chargement atteint 100%
            if(loading.progress >= 0.9f)
            {
                // La scène se lance
                loading.allowSceneActivation = true;
                // L'écran de chargement se détruit
                Destroy(screen);
            }

            yield return new WaitForSeconds(2);

        }
    }
}

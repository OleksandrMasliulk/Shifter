using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "New PingPong PostFX", menuName = "PostFX/PingPong")]
public class PingPongPostFXSO : PostFXSO {
    [SerializeField] private float _time;
    [SerializeField] private float _priority;

    public override void Trigger() {
        //postFXHandler.RunEffect(PingPong());
        PingPong();
    }

    private async void PingPong() {
        GameObject go = new GameObject();
        Volume volume = go.AddComponent<Volume>();
        volume.profile = _profile;
        volume.priority = _priority;
    
        float timer = 0f;
        float halfTime = _time / 2f;
        while (timer <= halfTime) {
            volume.weight = Mathf.Lerp(0f, 1f, timer / halfTime);
            await Task.Delay((int)(Time.deltaTime * 1000));
            timer += Time.deltaTime;
        }
        timer = 0f;
        while (timer <= halfTime) {
            volume.weight = Mathf.Lerp(1f, 0f, timer / halfTime);
            await Task.Delay((int)(Time.deltaTime * 1000));
            timer += Time.deltaTime;
        }
        volume.weight = 0f;
        Destroy(go);
    }
}
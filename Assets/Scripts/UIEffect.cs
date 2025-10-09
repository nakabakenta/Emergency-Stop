using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIEffect : MonoBehaviour
{
    public TextMeshProUGUI text;  //�t�F�[�h������e�L�X�g
    public float fadeInterval;    //�t�F�[�h�̎���(�b)
    private bool isFade = true;   //�t�F�[�h�t���O
    private float startAlpha = 1f;//�t�F�[�h�J�n���̓����x
    private float endAlpha = 0f;  //�ڕW�����x
    private float fadeTimer = 0f; //�t�F�[�h�̃^�C�}�[

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�t�F�[�h��i�߂�
        fadeTimer += Time.deltaTime;

        //���݂̓����x���v�Z
        float alpha = Mathf.Lerp(startAlpha, endAlpha, fadeTimer / fadeInterval);
        //�����x��ݒ�
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

        // �t�F�[�h���I�������A���̃t�F�[�h�ɐ؂�ւ���
        if (fadeTimer >= fadeInterval)
        {
            fadeTimer = 0f;// �^�C�}�[�����Z�b�g
            // �t�F�[�h�C���E�t�F�[�h�A�E�g��؂�ւ���
            isFade = !isFade;
            startAlpha = endAlpha;
            endAlpha = isFade ? 0f : 1f;//�ڕW�����x��؂�ւ�
        }
    }
}

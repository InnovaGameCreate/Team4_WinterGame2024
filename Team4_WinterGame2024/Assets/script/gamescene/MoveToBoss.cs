using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToBoss : MonoBehaviour
{
    // �ǂ̃g���K�[�ɐG�ꂽ�Ƃ��ɌĂ΂��
    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[�^�O�����I�u�W�F�N�g�ɐG�ꂽ�ꍇ
        if (other.CompareTag("player"))
        {
            // �ʂ̃V�[���Ɉړ�
            SceneManager.LoadScene("boss"); // �V�[�������w��
        }
    }
}

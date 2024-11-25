using UnityEngine;

namespace OtusUnityHomework.Model.SO
{
    [CreateAssetMenu(fileName = "UserData", menuName = "ScriptableObjects/UserData", order = 1)]
    public class UserData : ScriptableObject
    {
        public UserInfo UserInfo => _userInfo;
        public CharacterStatStorage CharacterStatStorage => _characterStatStorage;
        public PlayerLevel PlayerLevel => _playerLevel;
        
        [SerializeField] private UserInfo _userInfo;
        [SerializeField] private CharacterStatStorage _characterStatStorage;
        [SerializeField] private PlayerLevel _playerLevel;
    }
}
using UnityEngine;

namespace GameConstants
{
    public static class GlobalConst
    {
        public const string ShootAnimation = "Shoot";
        // Другие строки анимаций, если нужно

        // Статические хеши для анимаций
        public static readonly int Shoot = Animator.StringToHash(ShootAnimation);
        // Хеши для других анимаций
    }
}
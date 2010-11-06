using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shootter
{
    /*
     * Вектор в трехмерном пространстве.
     * Используется для определения направления.
     */
    public struct Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
    /*
     * Точка в трехмерном пространстве.
     * Используется для определения положения.
     */
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    /*
     * Класс абстрактной пули.
     */
    public abstract class AbstractBullet
    {
        /*
         * Калибр пули.
         */
        public double Caliber { get; set; }
        /*
         * Текущие координаты пули.
         */
        public Point3D Location { get; set; }
        /*
         * Текущее направление пули.
         */
        public Vector3D Direction { get; set; }
        /*
         * Начало движения пули.
         */
        public void StartMovement()
        {
            // Реализация начала движения
        }
        /*
         * Метод поражения цели.
         * Так как разные типы пуль поражают цель по-разному,
         * то метод должен быть реализован в подклассах.
         */
        public abstract void HitTarget(object target);
        /*
         * Метод, реализующий движение пули.
         * Так как разные типы пуль имеют разную траекторию движения,
         * то метод должен быть реализован в подклассах.
         */
        public abstract void Movement();

    }
    /*
     * Класс пули для автоматического оружия.
     */
    public class AutomaticBullet : AbstractBullet
    {
        public override void HitTarget(object target)
        {
            // реализация поражения цели target
        }

        public override void Movement()
        {
            // реализация алгоритма движения пули
        }
    }
    /*
     * Класс пули для дробовика.
     */
    public class ShotgunBullet : AbstractBullet
    {
        public override void HitTarget(object target)
        {
            // реализация поражения цели target
        }

        public override void Movement()
        {
            // реализация алгоритма движения пули
        }
    }

}
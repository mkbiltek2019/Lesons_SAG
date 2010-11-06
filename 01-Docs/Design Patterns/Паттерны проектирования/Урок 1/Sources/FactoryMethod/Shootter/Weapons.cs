using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shootter
{
    /*
     * Класс абстрактного оружия
     */
    public abstract class AbstractWeapon
    {
        /*
         * Фабричный метод для создания пули.
         */
        protected abstract AbstractBullet CreateBullet();

        /*
         * Текущее положение оружия
         */
        public Point3D Location { get; protected set; }
        /*
         * Направление оружия
         */
        public Vector3D Direction { get; protected set; }
        /*
         * Калибр оружия
         */
        public double Caliber { get; protected set; }

        /*
         * Метод, производящий выстрел.
         * Возвращает экзепмляр созданной пули.
         */
        public AbstractBullet Shoot()
        {
            // создание объекта пули с помощью фабричного метода
            AbstractBullet bullet = CreateBullet();
            // настройка пули на текущие параметры оружия
            bullet.Caliber = this.Caliber;
            bullet.Location = this.Location;
            bullet.Direction = this.Direction;
            // начать движение пули
            bullet.StartMovement();
            // возвратить экземпляр пули
            return bullet;
        }
    }

    /*
     * Класс автоматического оружия.
     */
    public class AutomaticWeapon : AbstractWeapon
    {
        public AutomaticWeapon()
        {
            this.Caliber = 20;
        }

        /*
         * Реализация фабричного метода.
         * Создает экземпляр пули,
         * специфический для текущего типа оружия.
         */
        protected override AbstractBullet CreateBullet()
        {
            return new AutomaticBullet();
        }
    }

    /*
     * Класс дробовика.
     */
    public class Shotgun : AbstractWeapon
    {
        public Shotgun()
        {
            this.Caliber = 50;
        }

        /*
         * Реализация фабричного метода.
         * Создает экземпляр пули,
         * специфический для текущего типа оружия.
         */
        protected override AbstractBullet CreateBullet()
        {
            return new ShotgunBullet();
        }
    }
}

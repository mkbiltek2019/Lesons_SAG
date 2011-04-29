using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ChocoPlanet.Views
{
    public class DynamicViewPage : ViewPage
    {
        // Скрываем модель класса предка и заменяем его на dynamic
        public new dynamic Model { get; private set; }

        protected override void SetViewData(ViewDataDictionary viewData)
        {
            base.SetViewData(viewData);

            // Создаем динамический объект, который использует private рефлексию над объектом модели
            Model = new ReflectionDynamicObject() { RealObject = ViewData.Model };
        }

        class ReflectionDynamicObject : DynamicObject
        {
            internal object RealObject { get; set; }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                // Возвращаем значение свойства
                result = RealObject.GetType().InvokeMember(
                  binder.Name,
                  BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                  null,
                  RealObject,
                  null);

                // Всегда возвращаем true, так как InvokeMember вызовет исключение, если что-то пойдет не так
                return true;
            }
        }
    }
}
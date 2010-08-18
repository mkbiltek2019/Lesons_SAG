#region Copyright and License Information

// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright © Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license

#endregion

using System.Collections.ObjectModel;

namespace Mvvm.Model
{
    /// <summary>
    /// Represents collection of persons
    /// </summary>
    public class DairyItemCollection : ObservableCollection<DairyItem>
    {
        /// <summary>
        /// Generates sample persons
        /// </summary>
        /// <returns></returns>
        public static DairyItemCollection Generate()
        {
            DairyItemCollection dairyItemCollection = new DairyItemCollection();
            dairyItemCollection.Add(DairyItem.Create("03.04.10", "Main bussiness", "Somework to do today", 1, 0));
            dairyItemCollection.Add(DairyItem.Create("03.04.10", "Main some little bussiness", "Somework to do today", 1, 1));
            dairyItemCollection.Add(DairyItem.Create("03.04.10", "Go to dinner", "Somework to do today just eat", 2, 0));
            dairyItemCollection.Add(DairyItem.Create("06.04.10", "Important breakfast", "Somework to do today", 3, 1));
            dairyItemCollection.Add(DairyItem.Create("06.04.10", "Some bussiness events", "Somework to do today", 1, 0));
            dairyItemCollection.Add(DairyItem.Create("07.04.10", "Need to buy", "Somework to do today", 1, 1));
            dairyItemCollection.Add(DairyItem.Create("07.04.10", "Go to that", "Somework to do today", 2, 0));
            dairyItemCollection.Add(DairyItem.Create("07.04.10", "Incompleted job", "Somework to do today", 1, 0));
            dairyItemCollection.Add(DairyItem.Create("08.04.10", "Go home and rest", "Somework to do today", 0, 1)); 

            return dairyItemCollection;
        }
    }
}

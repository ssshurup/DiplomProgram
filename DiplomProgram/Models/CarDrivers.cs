//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiplomProgram.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarDrivers
    {
        public int id { get; set; }
        public Nullable<int> idCar { get; set; }
        public Nullable<int> idDrivers { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Drivers Drivers { get; set; }
    }
}
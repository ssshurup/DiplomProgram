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
    
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            this.BranchStaff = new HashSet<BranchStaff>();
            this.Client = new HashSet<Client>();
        }
    
        public int id { get; set; }
        public string FIO { get; set; }
        public string Dolchnost { get; set; }
        public string Phone { get; set; }
        public Nullable<double> Salary { get; set; }
        public Nullable<System.DateTime> DataPrinatia { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public Nullable<int> Rolid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BranchStaff> BranchStaff { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Client { get; set; }
        public virtual rol rol { get; set; }
    }
}
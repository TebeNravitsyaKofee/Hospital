//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital
{
    using System;
    using System.Collections.Generic;
    
    public partial class doc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public doc()
        {
            this.list = new HashSet<list>();
        }
    
        public int id_doc { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string last_name { get; set; }
        public string p_num { get; set; }
        public Nullable<int> id_position { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    
        public virtual position position { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<list> list { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlLaba
{
    using System;
    using System.Collections.Generic;
    
    public partial class Feedback
    {
        public int FeedbackID { get; set; }
        public int Customer_id { get; set; }
        public int Product_id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Products Products { get; set; }
    }
}

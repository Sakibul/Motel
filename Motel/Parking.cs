//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Motel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parking
    {
        public byte Id { get; set; }
        public int GuestId { get; set; }
        public string VehicleRegistration { get; set; }
    
        public virtual Guest Guest { get; set; }
    }
}

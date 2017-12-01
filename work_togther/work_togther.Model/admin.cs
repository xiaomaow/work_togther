namespace work_togther.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("admin")]
    public partial class admin
    {
        public int id { get; set; }

        [StringLength(50)]
        public string login_name { get; set; }

        [StringLength(50)]
        public string login_password { get; set; }

        [StringLength(50)]
        public string real_name { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        public DateTime? create_time { get; set; }
    }
}

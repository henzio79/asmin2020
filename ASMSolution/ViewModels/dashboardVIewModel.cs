using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ASM_UI.Models
{

    public class dashboard_chart01_ViewModel
    {
        public int department_id { get; set; }
        
        public string department_code { get; set; }

        public string department_name { get; set; }

        public int asset_qty { get; set; }

        public decimal asset_value { get; set; }

    }



    public class dashboard_chart02_ViewModel
    {
        public int department_id { get; set; }

        public string department_code { get; set; }

        public string department_name { get; set; }

        public int mutation_qty { get; set; }

        public int dispose_qty { get; set; }

    }





    public class dashboard_chart03_ViewModel
    {
        public ms_asset_register_pic register_pic { get; set; }

        public string asset_qty { get; set; }

        public string asset_value { get; set; }

    }


}
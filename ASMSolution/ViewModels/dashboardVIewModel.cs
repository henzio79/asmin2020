using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ASM_UI.Models
{
    public class dashboard_chart01_ViewModel
    {
        public string department_code { get; set; }

        public string asset_qty { get; set; }

        public string asset_value { get; set; }

    }


    public class dashboard_chart02_ViewModel
    {
        public string category_code { get; set; }

        public string asset_qty { get; set; }

        public string asset_value { get; set; }

    }

    public class dashboard_chart03_ViewModel
    {
        public string site_code { get; set; }

        public string asset_qty { get; set; }

        public string asset_value { get; set; }

    }


}
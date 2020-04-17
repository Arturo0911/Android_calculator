using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace calculator.Classes
{
    [Table("calculate")]
    public class calculate
    {
        [PrimaryKey, AutoIncrement] // usaremos un valor de identificador con autoincrement para poder hacer el "Select *from "
        public int Id
        {
            get;
            set;
        }


        public int ValorOrganico
        {
            get;
            set;
        }

        [MaxLength(12)]
        public int CosechaValue
        {
            get;
            set;
        }

        public bool MedidaFosforo
        {
            get;
            set;
        }

        public bool MedidaPotasio
        {
            get;
            set;
        }

        public float MedidaSacoFertilizante
        {
            get;
            set;
        }



    }
}
